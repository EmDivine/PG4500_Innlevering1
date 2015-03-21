using Robocode;
using PG4500_2015_Innlevering1;
using System;

namespace Robot
{
    class Driver
    {
        private malseb_horjan_Draziel _robot;
        private Scout _scout;
        private double _minDist;
        private double _enemyHeading;
        private double _enemyBearing;

        public Driver(malseb_horjan_Draziel robot)
        {
            _robot = robot;
            _minDist = _robot.Height;
        }

        public void Drive()
        {
            _robot.SetAhead(200);
            //_robot.Execute();
        }

        public void Evade(string type)
        {
            if (type.Equals("Wall"))
            {
                // If robot is close to a wall, it slows down, turns around (not smart, should be fixed), sets new couse (straight ahead) and 
                _robot.MaxVelocity = 4;
                _robot.Execute();
                _robot.SetTurnRight(WallSide());
                Drive();
                //_robot.Execute();
                _robot.MaxVelocity = 8;
                //_robot.Execute();

            }
            else if (type.Equals("Bot"))
            {
                //_robot.Out.WriteLine("{0}\t# Woah there! Too close to a different robot. Backing away to avoid damage.", _robot.Time);
                _robot.SetTurnRight(_enemyBearing + 90);
                _robot.SetAhead(500);
                _robot.Execute();
            }

            
        }

        /*
         * This will calculate what angle to turn based on where you are and where you are headed. 
         * Not 100% complete... needs exceptions for corners and testing whether the degrees are correct.
         */
        public double WallSide()
        {
            double value = 90;
            if (Math.Min(_robot.X, _robot.BattleFieldWidth - _robot.X) < (_minDist + 20))
            {
                if (_robot.X <= _minDist)
                {
                    if (_robot.Heading >= 225 && _robot.Heading <= 270)
                        value = -90;
                    else if (_robot.Heading >= 270 && _robot.Heading <= 315)
                        value = 90;
                }
                else if (_robot.X > _minDist)
                {
                    if (_robot.Heading >= 45 && _robot.Heading <= 90)
                        value = -90;
                    else if (_robot.Heading >= 90 && _robot.Heading <= 135)
                        value = 90;
                }
            }
            else if (Math.Min(_robot.Y, _robot.BattleFieldHeight - _robot.Y) < (_minDist + 20))
            {
                if (_robot.Y <= _minDist)
                {
                    if (_robot.Heading <= 225 && _robot.Heading >= 360)
                        value = -90;
                    else if (_robot.Heading >= 180 && _robot.Heading <= 135)
                        value = -90;
                }
                else if (_robot.Y > _minDist)
                {
                    if (_robot.Heading >= 225 && _robot.Heading <= 180)
                        value = 90;
                    else if (_robot.Heading >= 0 && _robot.Heading <= 90)
                        value = 90;  
                }
            }
            return value; // Returns 90 degrees by default.
        }


        public void OnScannedRobot(ScannedRobotEvent e)
        {
            _enemyBearing = e.Bearing;
            _enemyHeading = e.Heading;
        }


        public bool NearWall
        {
            get
            {
                return ((Math.Min(_robot.X, _robot.BattleFieldWidth - _robot.X) < (_minDist + 20)) || (Math.Min(_robot.Y, _robot.BattleFieldHeight - _robot.Y) < (_minDist + 20)));
            }
        }

        public bool NearBot
        {
            get
            {
                return ((Math.Min(_robot.X, _scout.TargetPosition.X - _robot.X) < (_minDist + 50)) || (Math.Min(_robot.Y, _scout.TargetPosition.Y - _robot.Y) < (_minDist + 50)));
            }
        }





    }



}
