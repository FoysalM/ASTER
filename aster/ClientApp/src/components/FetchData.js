import React, { Component } from 'react';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
      super(props);
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table'>
      </table>
    );
  }

  render() {

    return (
        <div>
            Nothing here
      </div>
    );
  }
}
