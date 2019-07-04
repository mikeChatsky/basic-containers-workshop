import React from 'react';
import icon from './price-tag.svg';

import './Item.css';

function Item(props) {
  return (
    <div className="item-container">
      <img src={icon} className="icon" alt="icon" />
      <span>{props.name}</span>
    </div>
  );
}

export default Item;
