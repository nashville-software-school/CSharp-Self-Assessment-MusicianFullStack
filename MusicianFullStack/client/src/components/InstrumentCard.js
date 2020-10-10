import React from 'react';

const InstrumentCard = (props) => {
  return (
    <div className={"instrument-card " + props.instrument.difficulty.label}>
      <span className="instrument-card__name">
        {props.instrument.name}
      </span>
      <span className="instrument-card__difficulty">
        <label>Difficulty:</label>
        <span>{props.instrument.difficulty.label}</span>
      </span>
    </div>
  );
};

export default InstrumentCard;