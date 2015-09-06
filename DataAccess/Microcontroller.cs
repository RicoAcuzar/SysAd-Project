using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace DataAccess
{
    /// <summary>
    /// Microcontroller hardware interface.
    /// </summary>
    public class Microcontroller : IDisposable
    {
        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// Serial port conduit for computer to microcontroller communication.
        /// </summary>
        private SerialPort _serial;

        /// <summary>
        /// Holds the states of the sockets on the device.
        /// </summary>
        private bool[] _states;
        #endregion


        //
        // Properties
        //
        #region Properties

        /// <summary>
        /// Gets the name of the serial port.
        /// </summary>
        public string PortName
        {
            get { return _serial.PortName; }
        }

        /// <summary>
        /// Gets the baud rate of the serial port connection.
        /// </summary>
        public int BaudRate
        {
            get { return _serial.BaudRate; }
        }

        /// <summary>
        /// Gets the state of the serial port whether it is open or not.
        /// </summary>
        public bool IsOpen
        {
            get { return _serial.IsOpen; }
        }

        /// <summary>
        /// Gets the states of the sockets.
        /// </summary>
        public bool[] States
        {
            get { return _states; }
        }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        /// <param name="portName">Name of the port.</param>
        /// <param name="baudRate">Speed of the port.</param>
        public Microcontroller(string portName, int baudRate)
        {
            _serial = new SerialPort(portName, baudRate);
            _serial.DataReceived += (sender, e) =>
            {
                if (DataReceived != null)
                    DataReceived(sender, e);
            };
            _serial.ErrorReceived += (sender, e) =>
            {
                if (ErrorReceived != null)
                    ErrorReceived(sender, e);
            };
            //                      sockA  sockB  led
            _states = new bool[3] { false, false, false };
        }
        #endregion


        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// Opens the communication line to the microcontroller.
        /// </summary>
        public void Open()
        {
            _serial.Open();
        }

        /// <summary>
        /// Closes the communication line to the microcontroller.
        /// </summary>
        public void Close()
        {
            _serial.Close();
        }

        /// <summary>
        /// Writes a string on to the device.
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            if (_serial.IsOpen) _serial.Write(text);
        }

        /// <summary>
        /// Sends a command to the device.
        /// </summary>
        /// <param name="command">Command to be sent.</param>
        public void SendCommand(Command command)
        {
            if (_serial.IsOpen)
            {
                _serial.Write((char)command + "");
                if (command == Command.TurnOffSocketA) _states[0] = false;
                else if (command == Command.TurnOnSocketA) _states[0] = true;
                else if (command == Command.TurnOffSocketB) _states[1] = false;
                else if (command == Command.TurnOnSocketB) _states[1] = true;
                else if (command == Command.TurnOffLED) _states[2] = false;
                else _states[2] = true;
            }
        }
        #endregion


        //
        // Events
        //
        #region Events

        /// <summary>
        /// Occurs when a data has been received.
        /// </summary>
        public event SerialDataReceivedEventHandler DataReceived;

        /// <summary>
        /// Occurs when an error occurs.
        /// </summary>
        public event SerialErrorReceivedEventHandler ErrorReceived;
        #endregion


        //
        // Data Definitions
        //
        #region Data Definitions
        public enum Command : byte
        {
            TurnOffSocketA = 65,
            TurnOnSocketA,
            TurnOffSocketB,
            TurnOnSocketB,
            TurnOffLED,
            TurnOnLED
        }
        #endregion


        //
        // IDisposable Members
        //
        #region IDisposable Members

        //
        // Fields
        //
        #region Fields

        /// <summary>
        /// Indicates whether Dispose() has already been called.
        /// </summary>
        bool disposed = false;

        /// <summary>
        /// Safe handle instance.
        /// </summary>
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        //
        // Methods
        //
        #region Methods

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Flag that indicates that this method has already been called.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                if (_serial.IsOpen)
                {
                    _serial.DiscardOutBuffer();
                    _serial.DiscardInBuffer();
                    _serial.Close();
                }
                _serial.Dispose();
            }

            disposed = true;
        }
        #endregion
        #endregion
    }
}
