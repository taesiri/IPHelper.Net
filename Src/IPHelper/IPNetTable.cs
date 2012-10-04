using System.Collections;
using System.Collections.Generic;

namespace IPHelper
{
    public class IPNetTable : IEnumerable<IPNetRow>
    {
        #region Private Fields

        private readonly IEnumerable<IPNetRow> _ipNetRows;

        #endregion

        #region Constructors

        public IPNetTable(IEnumerable<IPNetRow> tcpRows)
        {
            this._ipNetRows = tcpRows;
        }

        #endregion

        #region Public Properties

        public IEnumerable<IPNetRow> Rows
        {
            get { return this._ipNetRows; }
        }

        #endregion

        #region IEnumerable<TcpRow> Members

        public IEnumerator<IPNetRow> GetEnumerator()
        {
            return this._ipNetRows.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._ipNetRows.GetEnumerator();
        }

        #endregion
    }
}
