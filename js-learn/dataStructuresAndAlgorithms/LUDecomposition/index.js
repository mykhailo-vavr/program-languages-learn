import { model } from './model.js';
import { view } from './view.js';

let controller = {
  start() {
    let btn = document.querySelector('.btn');
    btn.addEventListener('click', model.onClick.bind(model));

    view.create(2);

    let list = document.querySelector('#list');
    list.addEventListener('change', view.onChange.bind(view));
  },
};

controller.start();
