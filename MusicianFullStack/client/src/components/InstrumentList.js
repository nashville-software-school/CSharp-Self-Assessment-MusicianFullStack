import React, { useContext, useEffect } from 'react';
import { InstrumentContext } from '../providers/InstrumentProvider';

const InstrumentList = () => {
  const { instruments, getInstruments } = useContext(InstrumentContext);

  useEffect(() => {
    getInstruments();
  }, []);

  return (
    <>
      <h1>Instrument List</h1>
      {instruments.map(instrument =>
        <div>{instrument.name}</div>
      )}
    </>
  );
}

export default InstrumentList;