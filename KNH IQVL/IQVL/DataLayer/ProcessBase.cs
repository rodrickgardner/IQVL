using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVL.DataLayer
{
    public class ProcessBase
    {
        
            #region "Constructor"
            public ProcessBase()
            {
                _Connection = null;
                _Transaction = null;
                _HashParams = null;

            }
            #endregion

            #region "Custom Functions"
            protected object _Connection;
            protected object _Transaction;
            protected object _HashParams;

            public object Connection
            {
                get { return _Connection; }
                set { _Connection = value; }
            }

            public object Transaction
            {
                get { return _Transaction; }
                set { _Transaction = value; }
            }

            public object HashParams
            {
                get { return _HashParams; }
                set { _HashParams = value; }
            }
            #endregion
        }
    }

