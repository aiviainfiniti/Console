const DistinctList = (arr) => {
    const uniqueElements = new Set(arr);
    return  arr.length - uniqueElements.size; //Array.from(uniqueElements);
};

let input = [1, 200, 300, 4, 5, 1, 2, 3];
console.log(`Output: ${DistinctList(input)}`);