export let view = {
  onChange(event) {
    this.create(+event.target.value);
  },

  create(count) {
    this.destroy();

    let container = document.createElement('div');
    container.classList.add('matrix');

    for (let i = 0; i < count; i++) {
      container.append(this.createRow(count));
    }

    let list = document.querySelector('#list');
    list.after(container);
    this.container = container;
  },

  createRow(count) {
    let row = document.createElement('div');
    row.classList.add('matrix-row');

    for (let i = 0; i < count; i++) {
      row.append(this.createTextInput());
    }

    return row;
  },

  createTextInput() {
    let input = document.createElement('input');
    input.setAttribute('type', 'number');
    input.setAttribute('placeholder', '0');
    return input;
  },

  createSpan(text) {
    let span = document.createElement('span');
    span.innerHTML = text;
    return span;
  },

  showMatrix(matrix, matrixName) {
    let matrixToShow = document.createElement('div');
    matrixToShow.classList.add('matrix-to-show');
    matrixToShow.innerHTML = `<h3>${matrixName || ''}:</h3>`;

    for (let line of matrix) {
      let row = document.createElement('div');
      for (let num of line) {
        row.append(this.createSpan(+num.toFixed(2)));
      }
      matrixToShow.append(row);
    }

    let textArea = document.querySelector('.text-area');
    textArea.append(matrixToShow);
  },

  clearTextArea() {
    let textArea = document.querySelector('.text-area');
    textArea.innerHTML = '';
  },

  destroy() {
    if (this.container) {
      this.container.remove();
    }
    this.clearTextArea();
  },
};
