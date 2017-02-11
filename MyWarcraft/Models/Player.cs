﻿using System.Collections.Generic;
using System;
using MyWarcraft.Models.Events;
using System.Threading;
using NLog;
using MyWarcraft.Models.Buildings;
using MyWarcraft.Models.Board;
using MyWarcraft.Models.Capabilities;
using MyWarcraft.Models.Units;
using MyWarcraft.Models.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace MyWarcraft.Models
{
    public class Player : BindableBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Threads

        private Thread ExecuteCommandsThread;

        #endregion

        #region Events

        private void Pawn_GatherEvent()
        {
            foreach (var unit in units)
            {
                if (unit.GetType() == typeof(Farmer))
                {
                    if (Resources.ContainsKey(map.GetResource(pawn.Location)))
                    {
                        Resources[map.GetResource(pawn.Location)]++;
                    }
                    else
                    {
                        Resources.Add(map.GetResource(pawn.Location), 1);
                    }
                }
            }
            logger.Trace("Current resources: ");
            foreach (var resource in Resources)
            {
                logger.Trace("{0}: {1}", resource.Key.ToString(), resource.Value);
            }
        }

        private void Building_UnderConstructionEvent(AbstractBuildable sender, ConstructionArgs args)
        {
            logger.Trace("[{0}] Built {1}% of {2}", sender.GetHashCode(), args.Percentage, sender.GetType().Name);
            if (args.Percentage == 100)
            {
                sender.PropertyChanged -= Sender_PropertyChanged;
            }
        }

        private void Sender_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Fields
        private static int numberOfPlayers = 0;

        private Map map;
        private Dictionary<Resource, int> resources;
        private Pawn pawn;

        private Dictionary<int, AbstractBuildable> buildables;
        private List<AbstractBuilding> buildings;
        private Dictionary<Type, AbstractBuildCapability> buildCapabilities;
        private Dictionary<Type, AbstractTrainCapability> trainCapabilities;
        private List<AbstractUnit> units;
        //BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>();
        BlockingQueue<ICommand> commands = new BlockingQueue<ICommand>();
        private ICommandReader commandReader;

        #endregion

        #region Properties

        public Map Map
        {
            get
            {
                return map;
            }

            set
            {
                map = value;
            }
        }

        public Dictionary<Resource, int> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
            }
        }
        
        public List<AbstractUnit> Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
            }
        }
               
        public Pawn Pawn
        {
            get
            {
                return pawn;
            }

            set
            {
                pawn = value;
            }
        }

        public List<AbstractBuilding> Buildings
        {
            get
            {
                return buildings;
            }

            set
            {
                buildings = value;
            }
        }

        public int Id { get; private set; }

        public Dictionary<int, AbstractBuildable> Buildables
        {
            get
            {
                return buildables;
            }

            set
            {
                buildables = value;
            }
        }

        public Dictionary<Type, AbstractBuildCapability> BuildCapabilities
        {
            get
            {
                return buildCapabilities;
            }

            set
            {
                buildCapabilities = value;
            }
        }

        public Dictionary<Type, AbstractTrainCapability> TrainCapabilities
        {
            get
            {
                return trainCapabilities;
            }

            set
            {
                trainCapabilities = value;
            }
        }

        internal ICommandReader CommandReader
        {
            get
            {
                return commandReader;
            }

            set
            {
                commandReader = value;
            }
        }

        #endregion

        #region Constructors

        public Player(Map map, ICommandReader commandReader)
        {
            Map = map;
            Id = numberOfPlayers++;
            Resources = new Dictionary<Resource, int>();
            Units = new List<AbstractUnit>();
            Buildables = new Dictionary<int, AbstractBuildable>();
            Buildings = new List<AbstractBuilding>();
            TrainCapabilities = new Dictionary<Type, AbstractTrainCapability>();
            BuildCapabilities = new Dictionary<Type, AbstractBuildCapability>();

            ExecuteCommandsThread = new Thread(Execute);

            AddBuilding(new Farm(0, 0, 100));
            Pawn = new Pawn();
            Pawn.Location = new Point(0, 0);
            Pawn.GatherEvent += Pawn_GatherEvent;

            CommandReader = commandReader;
        }
        #endregion

        #region Public Methods

        /// <summary>
        ///     Start thread to execute commands from queue
        /// </summary>
        public void ExecuteCommands()
        {
            ExecuteCommandsThread.Start();
        }

        /// <summary>
        ///     Read commands using the command reader
        /// </summary>
        public void ReadCommands()
        {
            CommandReader.PushCommandEvent += PushCommandToQueue;
            CommandReader.ReadCommands();
        }

        #endregion

        #region Private Methods

        private void Build(AbstractBuildCapability buildCapability, AbstractBuilding building = null)
        {
            var newbuilding = buildCapability.Build(building);
            if (building == null)
            {
                AddBuilding(newbuilding);
            }
            else
            {
                RemoveBuilding(building);
                Buildings.Add(newbuilding);
                Buildables[building.Id] = newbuilding;
            }


        }

        private void TrainUnit(AbstractTrainCapability trainCapability, AbstractUnit unit = null)
        {
            var newunit = trainCapability.Train(unit);
            if (unit == null)
            {
                AddUnit(newunit);
            }
            else
            {
                RemoveUnit(unit);
                Units.Add(newunit);
                Buildables[unit.Id] = newunit;
            }
        }

    

        private void Move(int x, int y)
        {
            pawn.MoveToLocation(new Point(x, y));
        }

        private void Ghater()
        {
            Pawn.GatherResources();
        }

        private void AddUnit(AbstractUnit unit)
        {
            Units.Add(unit);
            Buildables.Add(unit.Id, unit);
        }

        private void AddBuilding(AbstractBuilding building)
        {
            Buildings.Add(building);
            Buildables.Add(building.Id, building);

            foreach (var capability in building.BuildCapabilities)
            {
                if (!BuildCapabilities.ContainsKey(capability.Key))
                    BuildCapabilities.Add(capability.Key, capability.Value);
            }

            foreach (var capability in building.TrainCapabilities)
            {
                if (!TrainCapabilities.ContainsKey(capability.Key))
                    TrainCapabilities.Add(capability.Key, capability.Value);
            }

            building.PropertyChanged += Building_PropertyChanged;
            building.StartBuilding();
        }

        private void Building_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveBuilding(AbstractBuilding building)
        {
            //TODO:unsubscribe from events
            Buildings.Remove(building);

        }

        private void RemoveUnit(AbstractUnit unit)
        {
            //TODO: unsubscribe from events
            Units.Remove(unit);
        }

        private void AddCommandToQueue(string cmdText)
        {
            var commandName = cmdText.Split(' ')[0];
            string args = "";
            if (cmdText.Contains(" "))
                args = cmdText.Split(' ')[1];
            PlayerCommand playerCommand;
            switch (commandName)
            {
                case "StopGame":
                    commands.TryAdd(new StopCommand());
                    break;
                case "Move":
                    {
                        int x;
                        int.TryParse(args.Split(',')[0], out x);
                        int y;
                        int.TryParse(args.Split(',')[1], out y);
                        playerCommand = new PlayerCommand(() =>
                        {
                            Move(x, y);
                        });
                        commands.TryAdd(playerCommand);
                    }
                    break;
                case "Gather":
                    {
                        playerCommand = new PlayerCommand(() =>
                        {
                            Ghater();
                        });
                        commands.TryAdd(playerCommand);
                    }
                    break;
                case "Build":
                    {
                        playerCommand = new PlayerCommand(() =>
                        {
                            switch (args)
                            {
                                case "Barrack":
                                    Build(BuildCapabilities[typeof(BuildBarrackCapability)]);
                                    break;
                                case "BowWorkshop":
                                    Build(BuildCapabilities[typeof(BuildBowWorkshopCapability)]);
                                    break;
                                default:
                                    break;
                            }
                        });
                        commands.TryAdd(playerCommand);
                    }
                    break;
                case "Attack":
                    {
                        playerCommand = new PlayerCommand(() =>
                        {
                            int unitID;
                            int attackStrength;
                            int.TryParse(args.Split(',')[0], out unitID);
                            int.TryParse(args.Split(',')[1], out attackStrength);
                            Attack(unitID, attackStrength);
                        });
                        commands.TryAdd(playerCommand);
                    }
                    break;
                case "List":
                    {
                        switch (args)
                        {
                            case "Units":
                                {
                                    playerCommand = new PlayerCommand(() =>
                                    {
                                        ListUnits();
                                    });
                                    commands.TryAdd(playerCommand);
                                }
                                break;
                            case "Buildings":
                                {
                                    playerCommand = new PlayerCommand(() =>
                                    {
                                        ListBuildings();
                                    });
                                    commands.TryAdd(playerCommand);
                                }
                                break;
                            default:
                                //TODO:...
                                break;
                        }
                    }
                    break;
                case "Train":
                    var playerTrainCommand = new PlayerCommand(() =>
                    {
                        string unitType = "";
                        int unitID = 0;
                        if (args.Contains(","))
                        {
                            unitType = args.Split(',')[0];
                            int.TryParse(args.Split(',')[1], out unitID);
                        }
                        else
                        {
                            unitType = args;
                        }
                        switch (unitType)
                        {
                            case "Farmer":
                                TrainUnit(TrainCapabilities[typeof(TrainFarmerCapability)]);
                                break;
                            case "Swordman":
                                //var swordman = new Farmer(0, 0, 100);
                                var unit = Buildables[unitID] as Farmer;
                                if (unit != null)
                                {
                                    //TrainUnit(new SwordManUpgrade1(unit));
                                    TrainUnit(TrainCapabilities[typeof(TrainSwordmanCapability)], unit);
                                }
                                else
                                {
                                    //TODO: throw exeception
                                }
                                break;
                            case "Bowman":
                                //var swordman = new Farmer(0, 0, 100);
                                var unit1 = Buildables[unitID] as Farmer;
                                if (unit1 != null)
                                {
                                    //TrainUnit(new BowmanUpgrade1(unit1));
                                    TrainUnit(TrainCapabilities[typeof(TrainBowmanCapability)], unit1);
                                }
                                else
                                {
                                    //TODO: throw exeception
                                }
                                break;
                            default:
                                break;
                        }

                    });
                    commands.TryAdd(playerTrainCommand);
                    break;
                default:
                    break;
            }
        }

        private void Attack(int unitID, int attackStrength)
        {
            throw new NotImplementedException();
        }

        private void PushCommandToQueue(object sender, PushCommandArgs args)
        {
            logger.Trace("Command received from reader: {0}", args.Command);
            AddCommandToQueue(args.Command);
        }

        private void Execute()
        {
            while (true)
            {
                ICommand command;
                commands.TryTake(out command);
                if(command.GetType() == typeof(StopCommand))
                {
                    break;
                }
                if (command != null)
                {
                    // Console.WriteLine("Executing command from thread [{0}]", Thread.CurrentThread.ManagedThreadId);
                    logger.Trace("Executing command {0} from thread [{1}]", command.GetType().Name, Thread.CurrentThread.ManagedThreadId);
                    command.Execute();
                }
                else
                {
                    //TODO: use Monitor to avoid this!
                    //Console.WriteLine("Bussy waiting!");
                }
            }
        }

        #endregion

        #region Test Methods

        public void ListUnits()
        {
            Console.WriteLine("Player Units:");
            foreach (var unit in Units)
            {
               Console.WriteLine(unit);
            }
            Console.WriteLine("");
        }

        public void ListBuildings()
        {
            Console.WriteLine("Player Buildings:");
            foreach (var building in Buildings)
            {
                Console.WriteLine(building);
            }
            Console.WriteLine("");
        }

        #endregion
    }
}