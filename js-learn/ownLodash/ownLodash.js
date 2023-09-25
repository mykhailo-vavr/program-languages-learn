// ----------------
//
//  Array methods
//
// ----------------

function chunk(arr, size = 1) {
  let chunkedArr = [];
  while (arr.length > size) {
    chunkedArr.push(arr.splice(0, size));
  }
  chunkedArr.push(arr);
  return chunkedArr;
}

function compact(arr) {
  return arr.filter(item => !!item);
}

function concat(arr, ...values) {
  return [].concat(arr, ...values);
}

function difference(arr, values) {
  return arr.filter(item => values.includes(item));
}

function differenceBy(arr, values, iteratee = identity) {
  if (typeof iteratee !== 'function') {
    iteratee = property(iteratee);
  }
  return arr.filter(item => {
    let itemToCompare = iteratee(item);
    for (const excludeItem of values) {
      if (itemToCompare === iteratee(excludeItem)) {
        return false;
      }
      return true;
    }
  });
}

function drop(arr, n = 1) {
  return arr.slice(n);
}

function dropRight(arr, n = 1) {
  if (n > arr.length) {
    return [];
  }
  return arr.slice(0, arr.length - n);
}

function fill(arr, value, start = 0, end = arr.length) {
  return arr.fill(value, start, end);
}

function last(arr) {
  return arr[length - 1];
}

// ----------------
//
//  Collection methods
//
// ----------------

function map(collection, iteratee = identity) {
  let arr = [];
  if (typeof iteratee !== 'function') {
    iteratee = property(iteratee);
  }
  for (const key in collection) {
    if (Object.hasOwnProperty.call(collection, key)) {
      arr.push(iteratee(collection[key]));
    }
  }
  return arr;
}

// ----------------
//
//  Function methods
//
// ----------------

function after(n, func) {
  let count = 0;
  return function (...args) {
    count < n ? count++ : func.apply(this, args);
  };
}

function ary(func, n) {
  return function (...args) {
    return func.apply(this, args.slice(0, n));
  };
}

function before(func, n) {
  let result,
    count = 0;
  return function (...args) {
    if (count < n) {
      result = func.apply(this, args);
      count++;
    }
    return result;
  };
}

function bind(func, context, ...args1) {
  return function (...args2) {
    let id = Symbol('id');
    context[id] = func;
    let result = context[id](...args1, ...args2);
    delete context[id];
    return result;
  };
}

function bindKey(obj, key, ...args1) {
  return function (...args2) {
    return obj[key].apply(obj, [...args1, ...args2]);
  };
}

function curry(func, arity) {
  arity = arity !== undefined ? arity : func.length;
  return function curryHelp(...args) {
    return args.length >= arity
      ? func.apply(this, args)
      : curryHelp.bind(this, ...args);
  };
}

function curryRight(func, arity) {
  arity = arity !== undefined ? arity : func.length;
  let arr = [];
  return function curryHelp(...args) {
    arr.unshift(...args);
    if (arr.length >= arity) {
      let result = func.apply(this, arr);
      arr = [];
      return result;
    }
    return curryHelp.bind(this);
  };
}

function debounce(func, wait) {
  let isCalled = false;
  return function (...args) {
    if (isCalled) {
      return;
    }
    func.apply(this, args);
    isCalled = true;
    setTimeout(() => (isCalled = false), wait);
  };
}

function defer(func, ...args) {
  return setTimeout(func.bind(this, ...args), 1);
}

function delay(func, wait, ...args) {
  return setTimeout(func.bind(this, ...args), wait);
}

function flip(func) {
  return function (...args) {
    return func.apply(this, args.reverse());
  };
}

// ----------------
//
//  String methods
//
// ----------------

//helper
function strToCase(str, separator, iteratee = identity) {
  return str
    .replace(/[_-]/g, ' ')
    .trim()
    .replace(/[A-Z]/, str => ' ' + str)
    .split(' ')
    .filter(word => word !== '')
    .map(iteratee)
    .join(separator);
}

function camelCase(str) {
  return strToCase(str, '', capitalize);
}

function capitalize(str) {
  return str[0].toUpperCase() + str.slice(1).toLowerCase();
}

//helper
function lowerCaseWord(word) {
  return word.toLowerCase();
}

//helper
function upperCaseWord(word) {
  return word.toUpperCase();
}

//helper
function capitalizeFirst(str) {
  return str[0].toUpperCase() + str.slice(1);
}

function endsWith(str, target, pos) {
  return str.endsWith(target, pos || str.length - 1);
}

function kebabCase(str) {
  return strToCase(str, '-', lowerCaseWord);
}

function lowerCase(str) {
  return strToCase(str, ' ', lowerCaseWord);
}

function lowerFirst(str) {
  return str[0].toLowerCase() + str.slice(1);
}

function pad(str, length, chars = ' ') {
  let dif = length - str.length;
  if (dif <= 0) {
    return str;
  }

  let startCount = Math.floor(dif / 2);
  let endCount = Math.ceil(dif / 2);

  return (
    continueString(chars, startCount) +
    str +
    continueString(chars, endCount)
  );
}

function padEnd(str, length, chars = ' ') {
  let dif = length - str.length;
  return dif <= 0 ? str : str + continueString(chars, dif);
}

function padStart(str, length, chars = ' ') {
  let dif = length - str.length;
  return dif <= 0 ? str : continueString(chars, dif) + str;
}

//helper
function continueString(str, length) {
  let result = str;
  for (let i = 0; result.length < length; i++) {
    result += result[i];
  }
  return result;
}

function parseInteger(str) {
  return parseInt(str, 10);
}

function replace(str, pattern, replacement) {
  return str.replace(pattern, replacement);
}

function snakeCase(str) {
  return strToCase(str, '_', lowerCaseWord);
}

function split(str, separator, limit) {
  return str.split(separator, limit);
}

function startCase(str) {
  return strToCase(str, ' ', capitalizeFirst);
}

function startsWith(str, target, pos) {
  return str.startsWith(target, pos);
}

function repeat(str, n) {
  if (n <= 0) {
    return '';
  }
  if (n === 1) {
    return str;
  }
  return str + repeat(str, n - 1);
}

// ----------------
//
//  Util methods
//
// ----------------

function identity(value) {
  return value;
}

function property(path) {
  let pathArr = Array.isArray(path) ? path : path.split('.');
  return obj => {
    let value = obj;
    for (const pathPeace of pathArr) {
      value = value[pathPeace];
    }
    return value;
  };
}
