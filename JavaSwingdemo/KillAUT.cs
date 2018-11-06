/*
 * Created by Ranorex
 * User: tom
 * Date: 30/10/2018
 * Time: 08:57
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using Ranorex.AutomationHelpers.UserCodeCollections;
	
namespace JavaSwingdemo
{
    /// <summary>
    /// Description of KillAUT.
    /// </summary>
    [TestModule("3B81C045-BB30-4344-929B-931259BAA61F", ModuleType.UserCode, 1)]
    public class KillAUT : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public KillAUT()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            var repo = JavaSwingdemoRepository.Instance;
            var swingSet3 = repo.SwingSet3;
            try{
            	swingSet3.Self.Close();
            	Delay.Milliseconds(2000);
            	SystemLibrary.KillProcess("jp2launcher");
            }
            catch (Exception err){
            	Ranorex.Report.Warn("Something went wrong with Killing the App! Erro was " + err.Message);
            }
            
        }
    }
}
