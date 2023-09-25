export let gaussView = {
  onChange(event) {
    this.create(+event.target.value);
  },

  create(count) {
    this.destroy();

    let container = document.createElement('div');
    container.classList.add('equations-system');

    for (let i = 0; i < count; i++) {
      container.append(this.createRow(count));
    }

    let list = document.querySelector('#list');
    list.after(container);
    this.container = container;
  },

  createRow(count) {
    let row = document.createElement('div');
    row.classList.add('equations-system-row');

    for (let i = 0; i < count; i++) {
      row.append(this.createTextInput());
      row.append(this.createArgumentSpan(i + 1));
      let signSpan =
        i == count - 1 ? this.createSpan('=') : this.createSpan('+');
      row.append(signSpan);
    }

    row.append(this.createTextInput());

    return row;
  },

  createTextInput() {
    let input = document.createElement('input');
    input.setAttribute('type', 'number');
    input.setAttribute('placeholder', '0');
    return input;
  },

  createArgumentSpan(num) {
    let span = document.createElement('span');
    span.innerHTML = `x<sub>${num}</sub>`;
    return span;
  },

  createSpan(sign) {
    let span = document.createElement('span');
    span.innerHTML = sign;
    return span;
  },

  showSolutionStep(coefs) {
    let solutionsStep = document.createElement('div');
    solutionsStep.classList.add('solutions-step');

    for (let row of coefs) {
      let step = document.createElement('div');
      for (let coef of row) {
        step.innerHTML += `<span>${+coef.toFixed(2)}</span>`;
      }
      solutionsStep.append(step);
    }

    let textArea = document.querySelector('.text-area');
    textArea.append(solutionsStep);
  },

  showSolutions(solutions) {
    let solutionsDiv = document.createElement('div');
    solutionsDiv.classList.add('solutions');

    for (let i = 0; i < solutions.length; i++) {
      solutionsDiv.append(this.createArgumentSpan(i + 1));
      solutionsDiv.append(this.createSpan('='));
      solutionsDiv.append(this.createSpan(solutions[i]));
    }

    let textArea = document.querySelector('.text-area');
    textArea.append(solutionsDiv);
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
