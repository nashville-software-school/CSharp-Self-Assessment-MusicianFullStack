import React, { useEffect, useState } from 'react';
import InstrumentCard from './InstrumentCard';
import { getInstruments } from '../modules/instrumentManager';

const InstrumentList = () => {
  const [ instruments, setInstruments ] = useState([]);

  useEffect(() => {
    getInstruments().then(instruments => setInstruments(instruments));
  }, []);

  return (
    <>
      <h1>Instrument List</h1>
      <div className="instrument-list">
        {instruments.map(instrument =>
          <InstrumentCard
            key={instrument.id}
            instrument={instrument}
            allowEdit={true} />
        )}
      </div>
    </>
  );
}

export default InstrumentList;