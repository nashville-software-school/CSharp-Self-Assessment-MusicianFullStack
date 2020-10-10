import React from 'react';
import { Link } from 'react-router-dom';

const InstrumentCard = (props) => {
  return (
    <div className={"instrument-card " + props.instrument.difficulty.label}>
      <span className="instrument-card__name">
        {props.instrument.name}
        <Link to={`/edit/${props.instrument.id}`} title="edit">
          <i className="instrument-card__edit-button">&#9998;</i>
        </Link>
      </span>
      <span className="instrument-card__difficulty">
        <label>Difficulty:</label>
        <span>{props.instrument.difficulty.label}</span>
      </span>
    </div>
  );
};

export default InstrumentCard;