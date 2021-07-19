import React, { useEffect, useState } from 'react';
import InstrumentCard from './InstrumentCard';
import { searchInstruments } from '../modules/instrumentManager';

const InstrumentSearch = () => {
  const [ instruments, setInstruments ] = useState([]);
  const [ criterion, setCriterion ] = useState("");

  const doSearchInstruments = (criterion) => {
    searchInstruments(criterion)
      .then((instruments) => setInstruments(instruments));
  };

  useEffect(() => {
    doSearchInstruments(criterion);
  }, []);

  return (
    <>
      <h1>Instrument Search</h1>
      <div className="instrument-search__form">
        <input id="search" value={criterion} onChange={e => setCriterion(e.target.value)}/>
        <button onClick={() => doSearchInstruments(criterion)}>Search</button>
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