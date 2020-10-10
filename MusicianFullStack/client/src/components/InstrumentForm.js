import React, { useContext, useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { InstrumentContext } from '../providers/InstrumentProvider';
import { DifficultyContext } from '../providers/DifficultyProvider';

const InstrumentForm = () => {
  const history = useHistory();

  const { id } = useParams();
  const instrumentId = parseInt(id);

  const { getInstrument, updateInstrument } = useContext(InstrumentContext);
  const { difficulties, getDifficulties } = useContext(DifficultyContext);

  const [name, setName] = useState("");
  const [difficultyId, setDifficultyId] = useState(0);

  useEffect(() => {
    getInstrument(instrumentId)
      .then(instrument => {
        setName(instrument.name);
        setDifficultyId(instrument.difficultyId);
      });

    getDifficulties();
  }, []);

  const saveInstrument = () => {
    const instrument = {
      id: instrumentId,
      name: name,
      difficultyId: difficultyId
    };
    updateInstrument(instrument).then(() => history.push('/'));
  }

  const cancelUpdate = () => {
    history.push('/');
  };

  return (
    <>
      <h1>Edit Instrument</h1>
      <div className="instrument-form">
        <div className="instrument-form__input">
          <label htmlFor="name">Name</label>
          <input id="name" value={name}
            onChange={e => setName(e.target.value)} />
        </div>
        <div className="instrument-form__input">
          <label htmlFor="difficultyId">Difficulty</label>
          <select id="difficultyId" value={difficultyId}
            onChange={e => setDifficultyId(parseInt(e.target.value))}>
            {difficulties.map(option =>
              <option value={option.id}> {option.label} </option>
            )}
          </select>
        </div>
        <div className="instrument-form__button">
          <button onClick={cancelUpdate}>Cancel</button>
          <button className="primary" onClick={saveInstrument}>Save</button>
        </div>
      </div>
    </>
  )
}

export default InstrumentForm;