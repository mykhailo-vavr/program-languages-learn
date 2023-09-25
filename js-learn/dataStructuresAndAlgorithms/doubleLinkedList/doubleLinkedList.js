// Support class Node
class Node {
  constructor(data, next = null, prev = null) {
    this.data = data;
    this.next = next;
    this.prev = prev;
  }
}

// Main class DoubleLinkedList
class DoubleLinkedList {
  constructor(...data) {
    this.head = this.tail = null;
    this.size = 0;

    if (data.length != 0) {
      data.forEach((item) => this.push(item));
    }
  }

  // add data to the tail
  push(data) {
    if (!this.tail) {
      this.tail = this.head = new Node(data);
      this.size++;
      return;
    }

    let temp = new Node(data, this.tail, null);
    this.tail.prev = temp;
    this.tail = temp;
    this.size++;
  }

  // add data to the head
  unshift(data) {
    if (!this.head) {
      this.tail = this.head = new Node(data);
      this.size++;
      return;
    }

    let temp = new Node(data, null, this.head);
    this.head.next = temp;
    this.head = temp;
    this.size++;
  }

  // delete data from tail
  pop() {
    if (!this.tail) {
      return;
    }

    this.tail = this.tail.next;
    this.tail.prev = null;
    this.size--;
  }

  // delete data from head
  shift() {
    if (!this.head) {
      return;
    }

    this.head = this.head.prev;
    this.head.next = null;
    this.size--;
  }

  // add data by index
  insert(index, data) {
    if (!this.validIndex(index)) {
      return;
    }

    if (index === 0) {
      this.unshift(data);
      return;
    }

    if (index === this.size) {
      this.push(data);
      return;
    }

    let current = this.getCurrent(index);

    const newNode = new Node(data, current.next, current);
    current.next.prev = newNode;
    current.next = newNode;

    this.size++;
  }

  // delete data by index
  remove(index) {
    if (!this.validIndex(index) || !this.head) {
      return;
    }

    if (index === 0) {
      this.shift();
      return;
    }

    if (index === this.size - 1) {
      this.pop();
      return;
    }

    let current = this.getCurrent(index);

    current.next.prev = current.prev;
    current.prev.next = current.next;
    this.size--;
  }

  // delete all data
  clear() {
    this.head = null;
    this.tail = null;
    this.size = 0;
  }

  // return index of element with particular data
  findByData(data) {
    if (!this.head || data === undefined) {
      return;
    }

    let current = this.head;
    for (let i = 0; current; i++) {
      if (current.data === data) {
        return i;
      }
      current = current.prev;
    }
    return -1;
  }

  // return data of item by index
  findByIndex(index) {
    if (!this.validIndex(index) || !this.head) {
      return;
    }

    return this.getCurrent(index).data;
  }

  isEmpty() {
    return this.size === 0;
  }

  getHead() {
    return this.head?.data;
  }

  getTail() {
    return this.tail?.data;
  }

  // show all data from tail to head
  show() {
    if (this.isEmpty()) {
      console.log('List is empty');
      return;
    }

    let current = this.tail;
    for (let i = 0; i < this.size; i++) {
      console.log(current.data);
      current = current.next;
    }
  }

  // support methods
  getCurrent(index) {
    let current = index > this.size / 2 ? this.tail : this.head;

    if (index > this.size / 2) {
      for (let i = 0; i < this.size - index - 1; i++) {
        current = current.next;
      }
    } else {
      for (let i = 0; i < index; i++) {
        current = current.prev;
      }
    }

    return current;
  }

  validIndex(index) {
    if (
      isNaN(index) ||
      index > this.size ||
      index < 0 ||
      index === undefined
    ) {
      return false;
    }

    return true;
  }
}

const list = new DoubleLinkedList(/*1, 2, 3, 4, 5, 6, 7*/);

// list.push(1);
// list.push(2);
// list.push(3);
// list.push(4);
// list.push(5);
// list.push(6);
// list.unshift(0);
// list.pop();
// list.pop();
// list.shift();
// list.push(3);
// list.insert(1, 99);
// console.log('pos:', list.findByData(4));
// console.log('data:', list.findByIndex(7));
// list.remove();
//list.clear();
// console.log(list.isEmpty());
list.show();
// console.log(list.getHead());
console.log(list);
// console.log();
