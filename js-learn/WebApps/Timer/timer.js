class Timer {
  constructor(options) {
    this.options = options;
    this.start();
  }

  timeList = ['days', 'hours', 'minutes', 'seconds'];
  interval = 1000;

  start() {
    this.createTimer();
    this.intervalID = setInterval(
      this.setTime.bind(this),
      this.interval
    );
  }

  createTimer() {
    const timerHTML = `
      <div class="timer">
        <div class="timer-header">
          Countdown to
          <span class="header-event_name">${
            this.options.eventName || 'Unknown'
          }</span>:
        </div>
        <div class="timer-body"></div>
      </div>`;

    let container = this.options.container;

    container.insertAdjacentHTML(
      this.options.insertPosition || 'afterbegin',
      timerHTML
    );

    this.timer = container.querySelector('.timer');
    this.header = container.querySelector('.timer-header');
    this.timerBody = container.querySelector('.timer-body');

    for (const timeName of this.timeList) {
      this.timerBody.insertAdjacentHTML(
        'beforeend',
        this.createTimeCell(timeName)
      );
      this[timeName] = container.querySelector(
        `[data-time='${timeName}']`
      );
    }
  }

  createTimeCell(timeName) {
    return `
      <div class="timer-body-cell">
        <div class="time-cell" data-time="${timeName}">0</div>
        <div class="date-cell">${timeName}</div>
      </div>`;
  }

  eventHappened() {
    this.header.textContent = `The ${this.options.eventName} has already taken place`;
    clearInterval(this.intervalID);
    for (const timeName of this.timeList) {
      this[timeName].textContent = 0;
    }
  }

  setTime() {
    const timeDifference = this.getTimeDifference();

    if (timeDifference < 0) {
      this.eventHappened();
      return;
    }

    for (const timeName of this.timeList) {
      const capitalizeFirst = word =>
        word[0].toUpperCase() + word.slice(1);

      this[timeName].textContent =
        this['get' + capitalizeFirst(timeName)](timeDifference);
    }
  }

  getTimeDifference() {
    return new Date(this.options.eventDate - Date.now());
  }

  getDays(timestamp) {
    // timestamp / 1000ms / 60s / 60m / 24h
    return Math.floor(timestamp / 1000 / 60 / 60 / 24);
  }

  getHours(timestamp) {
    return Math.floor((timestamp / 1000 / 60 / 60) % 24);
  }

  getMinutes(timestamp) {
    return Math.floor((timestamp / 1000 / 60) % 60);
  }

  getSeconds(timestamp) {
    return Math.floor((timestamp / 1000) % 60);
  }
}

let timer = new Timer({
  eventName: 'big party',
  eventDate: new Date(2021, 9, 23, 20),
  container: document.body
});
