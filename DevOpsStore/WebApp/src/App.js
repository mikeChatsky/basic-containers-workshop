import React, { useState, useEffect } from 'react';
import Item from './Item/Item';

import './App.css';

function App() {
  const [items, setItems] = useState([]);

  const populateItems = async () => {
    const result = await fetch(`api/values`);

    setItems(await result.json());
  }

  useEffect(() => {
    populateItems();
  }, [])

  return (
    <div className="app">
      <div className="app-store">
        {items.map((item) =>
          <Item name={item.name}></Item>
        )}
      </div>
      <div className="credits">*Icons made by <a href="https://www.flaticon.com/authors/smashicons" title="Smashicons">Smashicons</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>
    </div>
  );
}

export default App;
