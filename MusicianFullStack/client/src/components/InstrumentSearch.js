import React, { useContext, useEffect, useState } from 'react';
import InstrumentCard from './InstrumentCard';
import { InstrumentContext } from '../providers/InstrumentProvider';

const InstrumentSearch = () => {
  const { instruments, searchInstruments } = useContext(InstrumentContext);
  const [ criterion, setCriterion ] = useState("");

  useEffect(() => {
    searchInstruments(criterion);
  }, []);

  return (
    <>
      <h1>Instrument Search</h1>
      <div className="instrument-search__form">
        <input id="search" value={criterion} onChange={e => setCriterion(e.target.value)}/>
        <button onClick={() => searchInstruments(criterion)}>Search</button>
      </div>
      <div className="instrument-list">
        {instruments.map(instrument =>
          <InstrumentCard 
            key={instrument.id}
            instrument={instrument}
            allowEdit={false} />
        )}
      </div>
    </>
  );
}

export default InstrumentSearch;