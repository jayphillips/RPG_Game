using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using Engine.Models;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        private Location _currentLocation;
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation 
        { 
            get { return _currentLocation; }
            set 
            { 
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CanMoveNorth));
                OnPropertyChanged(nameof(CanMoveSouth));
                OnPropertyChanged(nameof(CanMoveEast));
                OnPropertyChanged(nameof(CanMoveWest));
            }
        }

        public bool CanMoveNorth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCordinate, CurrentLocation.YCoordinate + 1) != null;
            }
        }

        public bool CanMoveSouth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        public bool CanMoveWest
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool CanMoveEast
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public World CurrentWorld { get; set; }
        public GameSession() // This is a constructor.
        {
            CurrentPlayer = new Player { Name = "Jay", CharacterClass = "Fighter", HitPoints = 10, Gold = 1000000, ExperiencePoints = 0, Level = 1 };

            CurrentWorld = WorldFactory.CreateWorld();
            
            CurrentLocation = CurrentWorld.LocationAt(0,0);

        }

        public void MoveNorth()
        {
            if (CanMoveNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCordinate, CurrentLocation.YCoordinate + 1);
            }
            
        }

        public void MoveSouth() 
            {
            if (CanMoveSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCordinate, CurrentLocation.YCoordinate - 1);
            }
                
            }

        public void MoveWest()
        {
            if (CanMoveWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCordinate - 1, CurrentLocation.YCoordinate);
            }
            
        }

        public void MoveEast()
        {
            if (CanMoveEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCordinate + 1, CurrentLocation.YCoordinate);
            }
            
        }

        
    }
}
