function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    function _validateMana(manaValue) {
        const invalidType = isNaN(manaValue),
            invalidRange = manaValue < 0;

        if (invalidType || invalidRange) {
            throw new Error(ERROR_MESSAGES.INVALID_MANA);
        }
    }
    function _validateEffect(effect) {
        const invalidType = typeof effect !== 'function';

        if (invalidType || (effect.length !== 1)) {
            throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
        }
    }
    function _validateBattleUnit(unit, message) {
        const invalidDamage = isNaN(unit.damage),
            invalidHealth = isNaN(unit.health),
            invalidCount = isNaN(unit.count);

        if (invalidDamage || invalidCount || invalidHealth) {
            throw new Error(message);
        }
    }
    function _validateRange(value, min, max, message) {

        if ((value < min) || (max < value)) {
            throw new Error(message);
        }
    }

    function _validateName(name) {

        const invalidType = typeof name !== 'string';

        if (invalidType) {
            throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
        }

        _validateRange(name.length, 2, 20, ERROR_MESSAGES.INVALID_NAME_LENGTH);

        const invalidSymbols = /[^a-zA-Z ]/.test(name);

        if (invalidSymbols) {
            throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
        }
    }


    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            _validateName(value);
            this._name = value;
        }

        get manaCost() {
            return this._manaCost;
        }

        set manaCost(value) {
            _validateMana(value);
            this._manaCost = value;
        }

        get effect() {
            return this._effect;
        }

        set effect(value) {
            _validateEffect(value);
            this._effect = value;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }

        set name(value) {
            _validateName(value);

            this._name = value;
        }

        get alignment() {
            return this._alignment;
        }

        set alignment(value) {
            if (typeof (value) === "undefined" || typeof (value) !== "string") {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE)
            }
            // good, neutral, evil
            if (value !== "good" && value !== "neutral" && value !== "evil") {
                throw new Error("Alignment must be good, neutral or evil!");
            }
            this._alignment = value;
        }
    }

    let armyUnitId = 0;
    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);
            this._id = (armyUnitId += 1);
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get id() {
            return this._id;
        }

        get damage() {
            return this._damage;
        }

        set damage(value) {
            if (isNaN(+value) || +value < 0 || +value > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
            this._damage = value;
        }

        get health() {
            return this._health;
        }

        set health(value) {
            if (isNaN(+value) || +value < 0 || +value > 200) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
            this._health = value;
        }

        get count() {
            return this._count;
        }

        set count(value) {
            if (isNaN(+value) || +value < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
            this._count = value;
        }

        get speed() {
            return this._speed;
        }

        set speed(value) {
            if (isNaN(+value) || +value < 0 || +value > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
            this._speed = value;
        }
    }

    class Comander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana() {
            return this._mana;
        }

        set mana(value) {
            if (isNaN(+value) || +value < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
            this._mana = value;
        }

    }
    function getSortingFunction(firstParameter, secondParameter) {
        return function (first, second) {
            if (first[firstParameter] < second[firstParameter]) {
                return -1;
            }
            else if (first[firstParameter] > second[firstParameter]) {
                return 1;
            }

            if (first[secondParameter] < second[secondParameter]) {
                return -1;
            }
            else if (first[secondParameter] > second[secondParameter]) {
                return 1;
            }
            else {
                return 0;
            }
        }
    }


    class Battlemanager {
        constructor() {
            this.commanders = [];
            this.armyUnits = [];
        }

        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }

        getArmyUnit(args) {
            let name = args.name;
            let alignment = args.alignment;
            let damage = args.damage;
            let health = args.health;
            let count = args.count;
            let speed = args.speed;
            let unit = new ArmyUnit(name, alignment, damage, health, count, speed);

            this.armyUnits.push(unit);
            return unit;
        }

        getCommander(name, alignment, mana) {
            return new Comander(name, alignment, mana);
        }

        addCommanders(...args) {
            for (let commander of args) {
                this.commanders.push(commander);
            }
            return this;
        }

        addArmyUnitTo(commanderName, armyUnit) {
            var commander = this.commanders.find(com => com.name == commanderName);
            commander.army.push(armyUnit);
            return this;
        }

        addSpellsTo(commanderName, ...spells) {
            var commander = this.commanders.find(com => com.name == commanderName);

            for (const spell of spells) {
                try {
                    _validateName(spell.name);
                    _validateMana(spell.manaCost);
                    _validateEffect(spell.effect);
                } catch (error) {
                    error.message = ERROR_MESSAGES.INVALID_SPELL_OBJECT;
                    throw error;
                }
            }

            commander.spellbook.push(...spells);


            return this;
        }

        findCommanders(query) {
            return this.commanders.filter(function (item) {
                return Object.keys(query).every(function (prop) {
                    return query[prop] === item[prop];
                });
            }).sort(function (a, b) {
                return a.name - b.name;
            });
        }

        findArmyUnitById(id) {
            for (let unit of this.armyUnits) {
                if (unit.id === id) {
                    return unit;
                }
            }
            return undefined;
        }

        findArmyUnits(query) {
            return this.armyUnits.filter(function (item) {
                return Object.keys(query).every(function (prop) {
                    return query[prop] === item[prop];
                });
            }).sort(function (a, b) {
                if (a.speed === b.speed) {
                    if (a.name < b.name) return -1;
                    if (a.name > b.name) return 1;
                    return 0;
                }
                return b.speed - a.speed;
            });
        }
        spellcast(casterName, spellName, targetUnitId) {
            let caster = this.commanders.find(c => c.name === casterName);
            if (typeof (caster) === "undefined") {
                throw new Error("Can't cast with non-existant commander " + casterName + "!")
            }

            let spellToCast = caster.spellbook.find(spell => spell.name === spellName);
            if (typeof (spellToCast) === "undefined") {
                throw new Error(casterName + " doesn't know " + spellName);
            }

            let unitToBeAtacked = this.armyUnits.find(u => u.id === targetUnitId);
            if (typeof (unitToBeAtacked) === "undefined") {
                throw new Error("Target not found!")
            }
            if (spellToCast.manaCost > caster.mana) {
                throw new Error("Not enough mana!");
            }

            spellToCast.effect(unitToBeAtacked);
            caster.mana -= spellToCast.manaCost;

            return this;
        }

        battle(attacker, defender) {
            _validateBattleUnit(attacker, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            _validateBattleUnit(defender, ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
            const defenderCountAfterBattle = Math.ceil(((defender.health * defender.count) - (attacker.damage * attacker.count)) / defender.health);

            if (defenderCountAfterBattle < 0) {
                defender.count = 0;
            } else {
                defender.count = defenderCountAfterBattle;
            }


            return this;
        }

    }

    return new Battlemanager();
}

module.exports = solve;