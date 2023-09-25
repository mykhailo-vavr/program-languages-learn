import { gaussModel as model } from './gaussModel.js';
import { gaussView as view } from './gaussView.js';

let gaussController = {
  start() {
    let btn = document.querySelector('.btn');
    btn.addEventListener('click', model.onClick.bind(model));

    view.create(2);

    let list = document.querySelector('#list');
    list.addEventListener('change', view.onChange.bind(view));
  },
};

gaussController.start();
