function solve(){
    return {
        mage(mageName){
            return {
                name: mageName,
                health: 100,
                mana: 100,
                cast(spell){
                    this.mana--;
                    console.log(`${mageName} cast ${spell}`);
                }
            }
        },
        fighter(fighterName){
            return {
                name: fighterName,
                health: 100,
                stamina: 100,
                fight(){
                    this.stamina--;
                    console.log(`${fighterName} slashes at the foe!`);
                }
            }
        },
    }
}