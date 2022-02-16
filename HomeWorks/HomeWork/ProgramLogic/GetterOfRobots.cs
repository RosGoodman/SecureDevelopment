﻿
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Entities;
using Common.DAL.Models.ModelsForAnExampleOfAnAbstractFactory.Factories;
using ProgramLogic.Factories;

namespace ProgramLogic
{
    /// <summary> Класс получения экземпляра робота. </summary>
    public class GetterOfRobots
    {
        /// <summary> Получить робота по его типу. </summary>
        /// <param name="type"> Тип робота. </param>
        /// <returns> Экземпляр робота. </returns>
        public Robot GetRobotByName(RobotTypes type)
        {
            switch (type)
            {
                case RobotTypes.CrawScrewdriverRobot:
                    return new Robot(new CrawScrewdriverRobotFactory()) { Name = "CrawScrewdriverRobot" };
                case RobotTypes.FlyCleanerRobot:
                    return new Robot(new FlyCleanerRobotFactory()) { Name = "FlyCleanerRobot" };
                case RobotTypes.RideHummerRobot:
                    return new Robot(new RideHummerRobotFactory()) { Name = "RideHummerRobot" };
            }
            return new Robot(new EmptyFrameRobotFactory()) { Name = "EmptyFrameRobot" };
        }
    }
}
