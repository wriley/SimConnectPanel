using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace SimConnectPanel
{

    public partial class Form1 : Form
    {
        SimConnect simconnect;
        const int WM_USER_SIMCONNECT = 0x0402;
        enum EVENT_ID
        {
            EVENT_PITOT_TOGGLE,
            EVENT_TOGGLE_MASTER_ALTERNATOR,
            EVENT_TOGGLE_MASTER_BATTERY,
            EVENT_FUEL_PUMP,
            EVENT_TOGGLE_BEACON_LIGHTS,
            EVENT_LANDING_LIGHTS_TOGGLE,
            EVENT_TOGGLE_TAXI_LIGHTS,
            EVENT_TOGGLE_NAV_LIGHTS,
            EVENT_STROBES_TOGGLE,
            EVENT_TOGGLE_AVIONICS_MASTER
        }

        enum GROUP_ID
        {
            GROUP0
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (simconnect == null)
            {
                try
                {
                    simconnect = new SimConnect("SimConnectPanel", this.Handle, WM_USER_SIMCONNECT, null, 0);
                    simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                    simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);
                    simconnect.OnRecvEvent += new SimConnect.RecvEventEventHandler(simconnect_OnRecvEvent);
                }
                catch (COMException ex)
                {
                    displayText("Unable to connect: " + ex.Message.ToString());
                }
            }
            else
            {
                displayText("Disconnected");
                button_Connect.Text = "Connect";
                simconnect.Dispose();
                simconnect = null;
            }
        }

        void simconnect_OnRecvEvent(SimConnect sender, SIMCONNECT_RECV_EVENT data)
        {
            displayText(data.uEventID.ToString());
        }

        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            button_Connect.Text = "Connect";
            displayText("Disconnected");
            simconnect.Dispose();
            simconnect = null;
        }

        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            button_Connect.Text = "Disconnect";
            displayText("Connected to FSX");

            
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_MASTER_ALTERNATOR, "TOGGLE_ALTERNATOR1");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_MASTER_BATTERY, "TOGGLE_MASTER_BATTERY");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_FUEL_PUMP, "FUEL_PUMP");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_BEACON_LIGHTS, "TOGGLE_BEACON_LIGHTS");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_LANDING_LIGHTS_TOGGLE, "LANDING_LIGHTS_TOGGLE");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_TAXI_LIGHTS, "TOGGLE_TAXI_LIGHTS");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_NAV_LIGHTS, "TOGGLE_NAV_LIGHTS");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_STROBES_TOGGLE, "STROBES_TOGGLE");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_PITOT_TOGGLE, "PITOT_HEAT_TOGGLE");
            simconnect.MapClientEventToSimEvent(EVENT_ID.EVENT_TOGGLE_AVIONICS_MASTER, "TOGGLE_AVIONICS_MASTER");
            
            

            
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_MASTER_ALTERNATOR, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_MASTER_BATTERY, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_FUEL_PUMP, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_BEACON_LIGHTS, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_LANDING_LIGHTS_TOGGLE, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_TAXI_LIGHTS, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_NAV_LIGHTS, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_STROBES_TOGGLE, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_PITOT_TOGGLE, false);
            simconnect.AddClientEventToNotificationGroup(GROUP_ID.GROUP0, EVENT_ID.EVENT_TOGGLE_AVIONICS_MASTER, false);


            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:0", EVENT_ID.EVENT_TOGGLE_MASTER_ALTERNATOR, 0, null, 0, false);
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:1", EVENT_ID.EVENT_TOGGLE_MASTER_BATTERY, 0, null, 0, false);
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:8", EVENT_ID.EVENT_FUEL_PUMP, 0, null, 0, true);
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:9", EVENT_ID.EVENT_TOGGLE_BEACON_LIGHTS, 0, null, 0, false);

            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:10", EVENT_ID.EVENT_LANDING_LIGHTS_TOGGLE, 0, null, 0, false);

            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:11", EVENT_ID.EVENT_TOGGLE_TAXI_LIGHTS, 0, null, 0, false);
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:12", EVENT_ID.EVENT_TOGGLE_NAV_LIGHTS, 0, null, 0, false);

            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:13", EVENT_ID.EVENT_STROBES_TOGGLE, 0, null, 0, false);
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:14", EVENT_ID.EVENT_PITOT_TOGGLE, 0, null, 0, false);
            
            simconnect.MapInputEventToClientEvent(GROUP_ID.GROUP0, "joystick:1:button:15", EVENT_ID.EVENT_TOGGLE_AVIONICS_MASTER, 0, null, 0, false);
            
            
            

            simconnect.SetInputGroupState(GROUP_ID.GROUP0, 1);
            
           
        }

        protected override void DefWndProc(ref Message m)
        {
            if (simconnect != null)
            {
                try
                {
                    simconnect.ReceiveMessage();
                }
                catch (COMException ex)
                {
                    throw ex;
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            if (simconnect != null)
            {
                displayText("Test");
            }
            else
            {
                displayText("Not connected");
            }
        }

        // Response number
        int response = 1;

        // Output text - display a maximum of 10 lines
        string output = "\n\n\n\n\n\n\n\n\n\n";

        void displayText(string s)
        {
            // remove first string from output
            output = output.Substring(output.IndexOf("\n") + 1);

            // add the new string
            output += "\n" + response++ + ": " + s;

            // display it
            richResponse.Text = output;
        }
    }
}