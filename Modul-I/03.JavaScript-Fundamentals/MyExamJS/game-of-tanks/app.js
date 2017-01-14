function solve(args) {
    function findTank(tankToMove, rows, cols) {
        let pos = [];
        for (let r = 0; r < rows; r += 1) {
            for (let c = 0; c < cols; c += 1) {
                if (field[r][c] === tankToMove) {
                    pos.push(r);
                    pos.push(c);
                    return pos;
                }
            }
        }
    }

    let [rows, cols] = args[0].split(' ').map(Number);
    let debrises = args[1].split(/;| /).map(Number);
    let moves = +args[2];

    let field = [];

    for (let i = 0; i < rows; i += 1) {
        field[i] = [];
    }

    for (let i = 0; i < debrises.length - 1; i += 2) {
        let r = debrises[i];
        let c = debrises[i + 1];

        field[r][c] = 'd';
    }

    let koce = 4;
    let cuki = 4;

    // put tanks Koce
    field[0][0] = 0;
    field[0][1] = 1;
    field[0][2] = 2;
    field[0][3] = 3;
    // CUki
    field[rows - 1][cols - 1] = 4;
    field[rows - 1][cols - 2] = 5;
    field[rows - 1][cols - 3] = 6;
    field[rows - 1][cols - 4] = 7;

    for (let i = 0; i < moves; i += 1) {
        let command = args[3 + i].split(' ');
        if (command[0] === 'mv') {
            let tankToMove = +command[1];
            let positionsToMove = +command[2];
            let dir = command[3];

            let pos = findTank(tankToMove, rows, cols);

            let foundObsticle = false;

            let r = pos[0];
            let c = pos[1];

            while (positionsToMove > 0) {
                if (dir === 'u') {
                    if (r - 1 >= 0) {
                        if (field[r - 1][c] === undefined) {
                            field[r][c] = undefined;
                            field[r - 1][c] = tankToMove;
                            r -= 1;
                        } else {
                            foundObsticle = true;
                        }
                    } else {
                        foundObsticle = true;
                    }
                } else if (dir === 'd') {
                    if (r + 1 <= rows - 1) {
                        if (field[r + 1][c] === undefined) {
                            field[r][c] = undefined;
                            field[r + 1][c] = tankToMove;
                            r += 1;
                        } else {
                            foundObsticle = true;
                        }
                    } else {
                        foundObsticle = true;
                    }
                } else if (dir === 'l') {
                    if (c - 1 >= 0) {
                        if (field[r][c - 1] === undefined) {
                            field[r][c] = undefined;
                            field[r][c - 1] = tankToMove;
                            c -= 1;
                        } else {
                            foundObsticle = true;
                        }
                    } else {
                        foundObsticle = true;
                    }
                } else if (dir === 'r') {
                    if (c + 1 <= cols - 1) {
                        if (field[r][c + 1] === undefined) {
                            field[r][c] = undefined;
                            field[r][c + 1] = tankToMove;
                            c += 1;
                        } else {
                            foundObsticle = true;
                        }
                    } else {
                        foundObsticle = true;
                    }
                }
                positionsToMove -= 1;
                if (foundObsticle) {
                    break;
                }
            }
        } else { // X

            let tankToShoot = +command[1];
            let dir = command[2];
            let coords = findTank(tankToShoot, rows, cols);

            let r = coords[0];
            let c = coords[1];
            let targetDestroyed = false;

            while (!targetDestroyed) {
                if (dir === 'u') {
                    if (r - 1 < 0) {
                        targetDestroyed = true;
                    } else {
                        if (field[r - 1][c] !== undefined) {
                            let destroyedTaget = field[r - 1][c];
                            field[r - 1][c] = undefined;
                            if (destroyedTaget === 0 || destroyedTaget === 1 || destroyedTaget === 2 || destroyedTaget === 3) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                koce--;
                            } else if (destroyedTaget === 4 || destroyedTaget === 5 || destroyedTaget === 6 || destroyedTaget === 7) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                cuki--;
                            }

                            if (koce === 0) {
                                console.log('Koceto is gg');
                                return;
                            } else if (cuki === 0) {
                                console.log('Cuki is gg');
                                return;
                            }
                            targetDestroyed = true;
                        } else {
                            r--;
                        }
                    }
                } else if (dir === 'd') {
                    if (r + 1 >= rows) {
                        targetDestroyed = true;
                    } else {
                        if (field[r + 1][c] !== undefined) {
                            let destroyedTaget = field[r + 1][c];
                            field[r + 1][c] = undefined;
                            targetDestroyed = true;
                            if (destroyedTaget === 0 || destroyedTaget === 1 || destroyedTaget === 2 || destroyedTaget === 3) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                koce--;
                            } else if (destroyedTaget === 4 || destroyedTaget === 5 || destroyedTaget === 6 || destroyedTaget === 7) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                cuki--;
                            }

                            if (koce === 0) {
                                console.log('Koceto is gg');
                                return;
                            } else if (cuki === 0) {
                                console.log('Cuki is gg');
                                return;
                            }
                        } else {
                            r++;
                        }
                    }
                } else if (dir === 'l') {
                    if (c - 1 < 0) {
                        targetDestroyed = true;
                    } else {
                        if (field[r][c - 1] !== undefined) {
                            let destroyedTaget = field[r][c - 1];
                            field[r][c - 1] = undefined;
                            targetDestroyed = true;
                            if (destroyedTaget === 0 || destroyedTaget === 1 || destroyedTaget === 2 || destroyedTaget === 3) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                koce--;
                            } else if (destroyedTaget === 4 || destroyedTaget === 5 || destroyedTaget === 6 || destroyedTaget === 7) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                cuki--;
                            }

                            if (koce === 0) {
                                console.log('Koceto is gg');
                                return;
                            } else if (cuki === 0) {
                                console.log('Cuki is gg');
                                return;
                            }
                        } else {
                            c--;
                        }
                    }
                } else if (dir === 'r') {
                    if (c + 1 >= cols) {
                        targetDestroyed = true;
                    } else {
                        if (field[r][c + 1] !== undefined) {
                            let destroyedTaget = field[r][c + 1];
                            field[r][c + 1] = undefined;
                            targetDestroyed = true;
                            if (destroyedTaget === 0 || destroyedTaget === 1 || destroyedTaget === 2 || destroyedTaget === 3) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                koce--;
                            } else if (destroyedTaget === 4 || destroyedTaget === 5 || destroyedTaget === 6 || destroyedTaget === 7) {
                                console.log('Tank ' + destroyedTaget + ' is gg');
                                cuki--;
                            }

                            if (koce === 0) {
                                console.log('Koceto is gg');
                                return;
                            } else if (cuki === 0) {
                                console.log('Cuki is gg');
                                return;
                            }
                        } else {
                            c++;
                        }
                    }
                }
            }

        }
    }
}

solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);