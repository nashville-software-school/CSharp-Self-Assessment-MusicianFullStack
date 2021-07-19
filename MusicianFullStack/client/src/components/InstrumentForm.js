import React, { useEffect, useState } from 'react';
import { useHistory, useParams } from 'react-router-dom';
import { getInstrument, updateInstrument } from '../modules/instrumentManager';
import { getDifficulties } from '../modules/difficultyManager';

const InstrumentForm = () => {
  const history = useHistory();

  const { id } = useParams();
  const instrumentId = parseInt(id);

  const [difficulties, setDifficulties] = useState([]);
  const [name, setName] = useState("");
  const [difficultyId, setDifficultyId] = useState(0);

  useEffect(() => {
    getInstrument(instrumentId)
      .then((instrument) => {
        setName(instrument.name);
        setDifficultyId(instrument.difficultyId);
      });

    getDifficulties()
      .then((difficulties) => setDifficulties(difficulties));
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

  if (name === "" || difficultyId === 0) {
    return null;
  }

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
              <option key={option.id} value={option.id}> {option.label} </option>
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