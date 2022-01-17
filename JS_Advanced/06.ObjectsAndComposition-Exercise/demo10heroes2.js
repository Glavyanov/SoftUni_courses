function solve(){
    function decorCast(spell){
        this.mana--;
        console.log(`${this.name} cast ${spell}`);
    }

    function decorFight(){
        this.stamina--;
        console.log(`${this.name} slashes at the foe!`);
    }

    const canCast = (state) => ({
        cast: decorCast,
        
    })

    const canFight = (state) => ({
        fight: decorFight,
        
    })

    const mage = (name) => {
        let state = {
            name,
            health: 100,
            mana: 100,
            
        }
        return Object.assign(state, canCast(state));
    }
    const fighter = (name) => {
        let state = {
            name,
            health: 100,
            stamina: 100,
            
        }
        return Object.assign(state, canFight(state));
    }
    return {mage,fighter};
}
let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

