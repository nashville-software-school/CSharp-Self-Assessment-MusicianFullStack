import React, { useContext, useEffect } from 'react';
import InstrumentCard from './InstrumentCard';
import { InstrumentContext } from '../providers/InstrumentProvider';

const InstrumentList = () => {
  const { instruments, getInstruments } = useContext(InstrumentContext);

  useEffect(() => {
    getInstruments();
  }, []);

  return (
    <>
      <h1>Instrument List</h1>
      <div className="instrument-list">
        {instruments.map(instrument =>
          <InstrumentCard 
            key={instrument.id}
            instrument={instrument} />
        )}
      </div>
    </>
  );
}

export default InstrumentList;