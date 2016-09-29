function stringLength(value, min, max) {
    return new Promise(function (resolve, reject) {
        if (!value || typeof (value ) !== 'string') {
            reject(`${value} is false like!`)
        }

        if (value.length >= min && value.length <= max) {
            resolve("OK")
        } else {
            reject(`Invalid value ${value}`);
        }
    });
}
export  default {
    stringLength
}
// export default {
//     lenght: function (text, min, max){
//         return new Promise(function(resolve, reject) {
//             if (text.length >= min && text.length <= max) {
//                 resolve('OK');
//             } else {
//                 reject('Text too long');
//             }
//         });
//     }
// }