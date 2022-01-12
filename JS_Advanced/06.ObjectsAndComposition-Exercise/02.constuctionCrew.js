function solve(obj){
        if (obj.dizziness) {
            obj.levelOfHydrated += (0.1 * obj.weight * obj.experience);
            obj.dizziness = false;
        }
    return obj;
}