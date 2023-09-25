class Node {
  constructor(data, key) {
    this.data = data;
    this.key = key;
    this.left = null;
    this.right = null;
  }
}

class BinaryTree {
  constructor() {
    this.root = null;
    this.height = 0;
    this.size = 0;
  }

  add(data, key) {
    if (data === undefined || key === undefined) {
      return;
    }

    if (!this.root) {
      this.root = new Node(data, key);
      this.size++;
      return;
    }

    let current = this.root;
    while (true) {
      if (key > current.key && current.right) {
        current = current.right;
      } else if (key < current.key && current.left) {
        current = current.left;
      } else if (key == current.key) {
        return;
      } else {
        break;
      }
    }

    let newNode = new Node(data, key);
    if (key > current.key) {
      current.right = newNode;
    } else {
      current.left = newNode;
    }
    this.size++;
  }

  find(key) {
    if (key === undefined) {
      return;
    }

    if (!this.root) {
      return undefined;
    }

    let current = this.root;
    while (true) {
      if (key == current.key) {
        return current.data;
      } else if (key > current.key && current.right) {
        current = current.right;
      } else if (key < current.key && current.left) {
        current = current.left;
      } else {
        return undefined;
      }
    }
  }

  show() {
    let current = this.root;
  }
}

let tree = new BinaryTree();

tree.add(1, 'first');
tree.add(3, 'second');
tree.add(0, 'second');
tree.add(2, 'second');
tree.add(2, 'second');
console.log(tree.find('second'));

console.log(tree);
