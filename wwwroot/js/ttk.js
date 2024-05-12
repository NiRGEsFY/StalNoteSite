let armorAdditionInfo = document.getElementById('armorTableTextAddition');
let armorMainInfo = document.getElementById('armorTableTextMain');
let armorImg = document.getElementById('armorImg');
let chooseArmorLevel = document.getElementById('chooseArmorLevel');
let chooseArmorMenu = document.getElementById('chooseArmorMenu');

let armorSet;
let apt;
let plate;
let morfin;
let range;
let weaponChooseList = [];

class Morfin{
    constructor(){
        this.Vitality = 2.5;
        this.HealEffect = 17.1;
        this.BulletResist = 18;
        this.BleadingResist = 15.75;
    };
}

class Medicine{
    constructor(id,name,healing,bleeding){
        this.Id = id,
        this.Name = name,
        this.Healing = healing,
        this.Bleeding = bleeding
    }
}
class Plate{
    constructor(id,name,defense,absorption){
        this.Id = id,
        this.Name = name,
        this.Defense = defense,
        this.Absorption = absorption
    }

}
class takenWeapon {
    constructor(div,item){
        this.Div = div;
        this.Item = item;
        this.Stats = null;
        this.Ammo = null;
    }
}

let listApt = [
    new Medicine('96430','Аптечка индивидуальная',4,-1),
    new Medicine('1r2o6','Аптечка научная',5,-1.5),
    new Medicine('7ly13','Аптечка проводника',7,-1.5),
    new Medicine('g4lk0','Аптечка армейская',6,-1.5),
    new Medicine('1r2o9','Без Аптечки',0,0)
];
let listPlate = [
    new Plate('ghj6ftgh','Стальная пластина V',385,10),
    new Plate('ghj6ftgh','Стальная пластина IV',320,10),
    new Plate('ghj6ftgh','Стальная пластина III',255,10),
    new Plate('ghj6ftgh','Стальная пластина II',190,10),
    new Plate('ghj6ftgh','Стальная пластина I',125,10),
    new Plate('r1f3sed','Композитная пластина V',385,20),
    new Plate('r1f3sed','Композитная пластина IV',320,20),
    new Plate('r1f3sed','Композитная пластина III',255,20),
    new Plate('r1f3sed','Композитная пластина II',190,20),
    new Plate('r1f3sed','Композитная пластина I',125,20),
    new Plate('gtyut6tdhgg','Керамическая пластина V',131.25,70),
    new Plate('gtyut6tdhgg','Керамическая пластина IV',109.38,70),
    new Plate('gtyut6tdhgg','Керамическая пластина III',87.5,70),
    new Plate('gtyut6tdhgg','Керамическая пластина II',65.62,70),
    new Plate('gtyut6tdhgg','Керамическая пластина I',43.75,70),
    new Plate('dtyj56ftyhty','Без пластины',0,0)
]

plate = listPlate[listPlate.length - 1];

let chooseAptPrototype = document.getElementById('chooseAptPrototype');
chooseAptPrototype.style.display = 'none';

let weaponItemPrototype = document.getElementById('weaponItemPrototype');
weaponItemPrototype.style.display = 'none';

function takeWay(ItemId, Type, SubType){
    let road = '../img/gameIcon/';
    if(Type){
        road +=  '/' + Type;
    }
    if(SubType){
        road += '/' + SubType;
    }
    if(ItemId){
        road +=  '/'+ ItemId + '.png';
    }
    return road;
}
function backKillTime(weapon,ammo,type){
    let dmg = 0;


    if(range >= weapon.DamageDecreaseStart){
        
        if(range >= weapon.DamageDecreaseEnd){
            dmg = weapon.EndDamage;
        }
        let partDamageChange = (weapon.StartDamage - weapon.EndDamage) / (weapon.DamageDecreaseEnd - weapon.DamageDecreaseStart);
        let damageDecrese = (range - weapon.DamageDecreaseStart)  * partDamageChange;
        dmg = weapon.StartDamage - damageDecrese;
    }
    else{
        dmg = weapon.StartDamage;
    }
    let tempPlate = {
        Name: plate.Name,
        Defense: plate.Defense,
        Absorption: plate.Absorption,
        Id: plate.Id
    }
    let health = 100;
    let additionHealth = 1;
    let effectivHealing = 1;
    let bulletResist = 0;
    let bleeding = -1;
    let BleedingProtection = 0;
    let healing = 0;
    if(morfin !== null && morfin !== undefined){
        additionHealth += morfin.Vitality/100;
        effectivHealing += (morfin.HealEffect/100);
        bulletResist += morfin.BulletResist;
        BleedingProtection += morfin.BleadingResist;
    }
    if(apt !== undefined && apt.Id !== '1r2o9'){
        healing += apt.Healing;
        bleeding += apt.Bleeding;
    }
    if(armorSet.PeriodicHealing > 0){
        healing += armorSet.PeriodicHealing;
    }
    bulletResist += armorSet.BulletResistance;
    BleedingProtection += armorSet.BleedingProtection;
    bleeding += armorSet.Bleeding;

    let shootOnSecond = weapon.RateOfFire/60;
    let tickRate = 1 / shootOnSecond;

    let allShote = 0;

    if(type === 'Head'){
        dmg *= weapon.DamageModifierHeadshot;
        for(let i = 0;health > 0;i++){
            let armorShot = bulletResist; 
            if(weapon.ArmorPenetration > 0){
                armorShot *= (100 - weapon.ArmorPenetration)/100;
            }
            if(ammo.ArmorPenetration > 0){
                armorShot *= (100 - ammo.ArmorPenetration)/100;
            }
            let sumHealth = (100 + armorShot) * additionHealth;
            
            let damageHealth = sumHealth - dmg;  
            health -= (sumHealth - damageHealth)/(sumHealth/100); 
            health += ((healing * effectivHealing * additionHealth) * tickRate);
            allShote = i;
            if(health > 100){
                break;
            }
        }
    }
    else if(type === 'Limb'){
        dmg *= weapon.DamageModifierLimb;
    }
    else{
        for(let i = 0;health > 0;i++){
            let armorShot = bulletResist; 
            if(weapon.ArmorPenetration > 0){
                armorShot *= (100 - weapon.ArmorPenetration)/100;
            }
            if(ammo.ArmorPenetration > 0){
                armorShot *= (100 - ammo.ArmorPenetration)/100;
            }
            let sumHealth = (100 + armorShot) * additionHealth;

            let damageHealth = sumHealth - dmg;  
        let damageTaken = (sumHealth - damageHealth)/(sumHealth/100); 
        if(tempPlate.Defense > 0 && tempPlate.Id !== 'dtyj56ftyhty' && weapon.ItemId !== 'knmdv'){
            if(weapon.ItemId === '4qnyn'){
                tempPlate.Defense = 0;
            }
            let plateRemoveDamage = damageTaken * tempPlate.Absorption / 100;
            if(tempPlate.Defense < plateRemoveDamage){
                plateRemoveDamage = tempPlate.Defense;
            }
            tempPlate.Defense -= plateRemoveDamage;
            damageTaken -= plateRemoveDamage;
        }

        health -= damageTaken;
        health += ((healing * effectivHealing * additionHealth) * tickRate);
        allShote = i;
        if(health > 100){
            break;
        }
    }
    }
    return (tickRate * allShote).toFixed(3);
}

let chooseAmmoMenu = document.getElementById('chooseAmmoMenu');
let chooseAmmoPrototype = document.getElementById('chooseAmmoPrototype');
chooseAmmoPrototype.style.display = 'none';
function refreshStats(){
    weaponChooseList.forEach(element =>{
        if(element.Stats === null){
            let newChild = weaponItemPrototype.cloneNode(true);
            newChild.style.display = 'grid';
            newChild.children[0].children[0].src = takeWay(element.Item.ItemId,element.Item.Type,element.Item.SubType);
            let ammo = element.Item.AmmoType;
            let AmmoList = [];
            inputData.Bullets.forEach(temp =>{
            if(ammo === '9 мм'){
                if(temp.Name.includes('9 мм') && !temp.Name.includes('9x39')){
                    AmmoList.push(temp);
                }
            }
            else if(ammo === '9x39')
            {
                if(temp.Name.includes('9x39')){
                    AmmoList.push(temp);
                }
            }
            else{
                if(temp.AmmoType.includes(ammo)){
                    AmmoList.push(temp);
                }
            }

            });
            element.Ammo = AmmoList[0];
            newChild.children[1].children[0].src = takeWay(element.Ammo.ItemId,'bullet');
            let listRemove = [];
            newChild.children[1].children[0].addEventListener('click',e=>{
                AmmoList.forEach(bullet=>{
                    let newAmmo = chooseAmmoPrototype.cloneNode(true);
                    newAmmo.style.display = 'flex';
                    newAmmo.children[0].textContent = bullet.Name;
                    newAmmo.children[1].src = takeWay(bullet.ItemId,'bullet');
                    newAmmo.children[2].textContent = 'Бронебойность: ' + bullet.ArmorPenetration +'%';
                    newAmmo.children[3].textContent = 'Кровотечение: ' + bullet.Bleeding + '%';
                    newAmmo.children[4].textContent = 'Останова: ' + bullet.StoppingPower;
                    newAmmo.children[5].textContent = 'Ожог: ' + bullet.Burning + '%';
                    chooseAmmoPrototype.after(newAmmo);
                    listRemove.push(newAmmo);
                    newAmmo.addEventListener('click',e=>{
                        chooseAmmoMenu.classList.remove('middleChoose');
                        element.Ammo = bullet;
                        newChild.children[1].children[0].src = takeWay(bullet.ItemId,'bullet');
                        listRemove.forEach(temp=>{
                            temp.remove();
                        });
                    });
                });
                chooseAmmoMenu.classList.add('middleChoose');
            });
            weaponItemPrototype.after(newChild);
            element.Stats = newChild;

            newChild.children[2].children[4].textContent = backKillTime(element.Item,element.Ammo) + ' сек. ';
            newChild.children[2].children[3].textContent = backKillTime(element.Item,element.Ammo,'Head') + ' сек. ';
            if(element.Item.Pottential > 0){
                newChild.children[3].textContent = element.Item.Name + ' +' + element.Item.Pottential;
            }
            else{
                newChild.children[3].textContent = element.Item.Name;
            }
        }
        else{

            element.Stats.children[2].children[4].textContent = backKillTime(element.Item,element.Ammo) + ' сек. ';
            element.Stats.children[2].children[3].textContent = backKillTime(element.Item,element.Ammo, 'Head') + ' сек. ';
        }
    });
}
let refreshInfo = document.getElementById('refreshInfo');
refreshInfo.addEventListener('click',refreshStats);







let chooseAptMenu = document.getElementById('chooseAptMenu');
let medicineConfig = document.getElementById('medicineConfig');
listApt.forEach(element =>{
    let newChild = chooseAptPrototype.cloneNode(true);
    newChild.style.display = 'flex';
    newChild.classList = ['chooseAptIcon']
    newChild.children[0].textContent = element.Name;
    newChild.children[1].src = takeWay(element.Id,'medicine');
    newChild.children[2].textContent = 'Лечение: ' + element.Healing;
    newChild.children[3].textContent = 'Кровотечение: ' + element.Bleeding;
    chooseAptPrototype.after(newChild);
    newChild.addEventListener('click',e=>{
        medicineConfig.src = newChild.children[1].src;
        apt = element;
        chooseAptMenu.classList.remove('middleChoose');
    })
});
let choosePlateMenu = document.getElementById('choosePlateMenu');
let choosePlatePrototype = document.getElementById('choosePlatePrototype');
let plateImg = document.getElementById('plateImg');
choosePlatePrototype.style.display = 'none';
listPlate.forEach(element =>{
    let newChild = choosePlatePrototype.cloneNode(true);
    newChild.style.display = 'flex';
    newChild.classList = ['chooseAptIcon']
    newChild.children[0].textContent = element.Name;
    newChild.children[1].src = takeWay(element.Id,'myOther');
    newChild.children[2].textContent = 'Броня: ' + element.Defense;
    newChild.children[3].textContent = 'Поглащение: ' + element.Absorption;
    choosePlatePrototype.after(newChild);
    newChild.addEventListener('click',e=>{
        plateImg.src = newChild.children[1].src;
        plate = element;
        choosePlateMenu.classList.remove('middleChoose');
    })
});
let choosePlateCancel = document.getElementById('choosePlateCancel');
choosePlateCancel.addEventListener('click', e=>{
    choosePlateMenu.classList.remove('middleChoose');
});
plateImg.addEventListener('click',e=>{
    choosePlateMenu.classList.add('middleChoose');
});

let chooseAptCancel = document.getElementById('chooseAptCancel');
chooseAptCancel.addEventListener('click',e=>{
    chooseAptMenu.classList.remove('middleChoose');
});
let medicineBox = document.getElementById('medicineBox');
medicineConfig.addEventListener('click',e=>{
    chooseAptMenu.classList.add('middleChoose');
});

let distance = document.getElementById('distance');
distance.addEventListener('change', e=>{
    range = distance.value;
});
let inputMorfin = document.getElementById('morfin');
inputMorfin.addEventListener('change',e=>{
    switch(inputMorfin.checked ){
        case false:
            morfin = null;
            break;
        case true:
            morfin = new Morfin();
            break;
    }
});




let armorPerLevelList = [
    [],[],[],[],[],
    [],[],[],[],[],
    [],[],[],[],[],[]
];
inputData.allArmorItems.forEach(element =>{
    switch(element.Pottential){
        case 0:
            armorPerLevelList[0].push(element);
            break;
        case 1:
            armorPerLevelList[1].push(element);
            break;
        case 2:
            armorPerLevelList[2].push(element);
            break;
        case 3:
            armorPerLevelList[3].push(element);
            break;
        case 4:
            armorPerLevelList[4].push(element);
            break;
        case 5:
            armorPerLevelList[5].push(element);
            break;
        case 6:
            armorPerLevelList[6].push(element);
            break;
        case 7:
            armorPerLevelList[7].push(element);
            break;
        case 8:
            armorPerLevelList[8].push(element);
            break;
        case 9:
            armorPerLevelList[9].push(element);
            break;
        case 10:
            armorPerLevelList[10].push(element);
            break;
        case 11:
            armorPerLevelList[11].push(element);
            break;
        case 12:
            armorPerLevelList[12].push(element);
            break;
        case 13:
            armorPerLevelList[13].push(element);
            break;
        case 14:
            armorPerLevelList[14].push(element);
            break;
        case 15:
            armorPerLevelList[15].push(element);
            break;
    }
});



let weaponPerLevelList =[
    [],[],[],[],[],
    [],[],[],[],[],
    [],[],[],[],[],[]
];

inputData.allWeaponItems.forEach(element =>{

    switch(element.Pottential){
        case 0:
            weaponPerLevelList[0].push(element);
            break;
        case 1:
            weaponPerLevelList[1].push(element);
            break;
        case 2:
            weaponPerLevelList[2].push(element);
            break;
        case 3:
            weaponPerLevelList[3].push(element);
            break;
        case 4:
            weaponPerLevelList[4].push(element);
            break;
        case 5:
            weaponPerLevelList[5].push(element);
            break;
        case 6:
            weaponPerLevelList[6].push(element);
            break;
        case 7:
            weaponPerLevelList[7].push(element);
            break;
        case 8:
            weaponPerLevelList[8].push(element);
            break;
        case 9:
            weaponPerLevelList[9].push(element);
            break;
        case 10:
            weaponPerLevelList[10].push(element);
            break;
        case 11:
            weaponPerLevelList[11].push(element);
            break;
        case 12:
            weaponPerLevelList[12].push(element);
            break;
        case 13:
            weaponPerLevelList[13].push(element);
            break;
        case 14:
            weaponPerLevelList[14].push(element);
            break;
        case 15:
            weaponPerLevelList[15].push(element);
            break;
    }
});
let chooseArmorStand = armorPerLevelList[0][0];
//Начало добаление всей брони
let chooseArmorListBox = document.getElementById('chooseArmorListBox');
let chooseArmorPrototype = document.getElementById('chooseArmorPrototype');



function refreshArmor(armor){
    let ArmorName = document.getElementById('armorTableTextName');
    ArmorName.textContent = armor.Name;

    let armorTableTextAddition = document.getElementById('armorTableTextAddition');
    let additionText = '';
    if(armor.PeriodicHealing !== 0){
        additionText += 'Переодическое лечение: ' + armor.PeriodicHealing + '%<br />';
    }
    if(armor.Bleeding !== 0){
        additionText += 'Кровотечение: ' + armor.Bleeding + '<br />';
    }
    if(armor.Stability !== 0){
        additionText += 'Стойкость: ' + armor.Stability + '%<br />';
    }

    if(armor.Stamina !== 0){
        additionText += 'Выносливость: ' + armor.Stamina + '%<br />';
    }
    if(armor.StaminaRegeneration !== 0){
        additionText += 'Восстановление выносливости: ' + armor.StaminaRegeneration + '%<br />';
    }
    if(armor.MoveSpeed !== 0){
        additionText += 'Скорость передвижения: ' + armor.MoveSpeed + '%<br />';
    }
    if(armor.CarryWeight !== 0){
        additionText += 'Переносимый вес: ' + armor.CarryWeight + 'кг<br />';
    }
    armorTableTextAddition.innerHTML = additionText;

    let armorTableTextMain = document.getElementById('armorTableTextMain');
    let mainText = '';

    if(armor.BulletResistance !== 0){
        mainText += 'Пулестойкость: ' + armor.BulletResistance + '<br />';
    }
    if(armor.LacerationProtection !== 0){
        mainText += 'Защита от разрыва: ' + armor.LacerationProtection + '<br />';
    }
    if(armor.ExplosionProtection !== 0){
        mainText += 'Защита от взрыва: ' + armor.ExplosionProtection + '<br />';
    }
    if(armor.BleedingProtection !== 0){
        mainText += 'Защита от кровотечения: ' + armor.BleedingProtection + '<br />';
    }
    if(armor.ResistanceToFire !== 0){
        mainText += 'Защита от огня: ' + armor.ResistanceToFire + '<br />';
    }

    armorTableTextMain.innerHTML = mainText;


}

var armorOnChoose = [];
armorPerLevelList[0].forEach(element=>{
    class armor {
        constructor(div,rank,type){
            this.Div = div;
            this.Rank = rank;
            this.Type = type;
        }
    }
    let newChild = chooseArmorPrototype.cloneNode(true);
    newChild.classList = ['chooseArmorIcon']
    newChild.children[0].textContent = element.Name;
    newChild.children[1].src = takeWay(element.ItemId,element.Type,element.SubType);
    newChild.children[2].textContent = 'П/У: ' + element.BulletResistance;

    newChild.addEventListener('click', e=>{
        let tempItem;

        armorPerLevelList[chooseArmorLevel.value].forEach(temp =>{
            if(temp.ItemId === element.ItemId){
                tempItem = temp;
                armorSet = tempItem;
            }
        });
        chooseArmorStand = tempItem;
        armorImg.src = takeWay(element.ItemId, element.Type, element.SubType);
        
        chooseArmorMenu.classList.remove('middleChoose');
        refreshArmor(tempItem);
        
    });

    chooseArmorPrototype.after(newChild);
    let tempItem = new armor(newChild,element.Rank,element.SubType);
    armorOnChoose.push(tempItem);
});
chooseArmorListBox.removeChild(chooseArmorPrototype);

armorSet = armorPerLevelList[0][0];
armorImg.src = takeWay(armorSet.ItemId, armorSet.Type, armorSet.SubType);
refreshArmor(armorPerLevelList[0][0]);

let TTKbutton = document.getElementById('TTKbutton');
let armorChooseType = document.getElementById('armorChooseType');
let armorChooseRank = document.getElementById('armorChooseRank');

TTKbutton.addEventListener('click', e=>{
    chooseArmorMenu.classList.add('middleChoose');
});

function refreshArmorChoose(){
    if(armorChooseRank.options[armorChooseRank.selectedIndex].value === 'None'){
        armorOnChoose.forEach(element=>{
            if(element.Type === armorChooseType.options[armorChooseType.selectedIndex].value){
                element.Div.style.display = 'flex';
            }
            else{
                element.Div.style.display = 'none';
            }
        })
        return;
    }
    if(armorChooseType.options[armorChooseType.selectedIndex].value === 'None'){
        armorOnChoose.forEach(element=>{
            if(element.Rank === armorChooseRank.options[armorChooseRank.selectedIndex].value){
                element.Div.style.display = 'flex';
            }
            else{
                element.Div.style.display = 'none';
            }
        })
        return;
    }

    armorOnChoose.forEach(element=>{
        if(element.Rank === armorChooseRank.options[armorChooseRank.selectedIndex].value && element.Type === armorChooseType.options[armorChooseType.selectedIndex].value){
            element.Div.style.display = 'flex';
        }
        else{
            element.Div.style.display = 'none';
        }
    })
}

armorChooseRank.addEventListener('change', refreshArmorChoose);
armorChooseType.addEventListener('change', refreshArmorChoose);
//Конец обработки форм для брони



//Начало обработки всего оружия
var weaponOnChoose = [];

let weaponChooseType = document.getElementById('weaponChooseType');
let weaponChooseRank = document.getElementById('weaponChooseRank');
let chooseWeaponListBox = document.getElementById('chooseWeaponListBox');

let addWeapon = document.getElementById('addWeapon');



function refreshWeaponChoose(){
    if(weaponChooseRank.options[weaponChooseRank.selectedIndex].value === 'None'){
        weaponOnChoose.forEach(element=>{
            if(element.Type === weaponChooseType.options[weaponChooseType.selectedIndex].value){
                element.Div.style.display = 'flex';
            }
            else{
                element.Div.style.display = 'none';
            }
        })
        return;
    }
    if(weaponChooseType.options[weaponChooseType.selectedIndex].value === 'None'){
        weaponOnChoose.forEach(element=>{
            if(element.Rank === weaponChooseRank.options[weaponChooseRank.selectedIndex].value){
                element.Div.style.display = 'flex';
            }
            else{
                element.Div.style.display = 'none';
            }
        })
        return;
    }

    weaponOnChoose.forEach(element=>{
        if(element.Rank === weaponChooseRank.options[weaponChooseRank.selectedIndex].value && element.Type === weaponChooseType.options[weaponChooseType.selectedIndex].value){
            element.Div.style.display = 'flex';
            
        }
        else{
            element.Div.style.display = 'none';
        }
    })
}
let chooseWeaponMenu = document.getElementById('chooseWeaponMenu');

addWeapon.addEventListener('click', e=>{
    chooseWeaponMenu.classList.add('middleChoose');
})

weaponChooseRank.addEventListener('change', refreshWeaponChoose);
weaponChooseType.addEventListener('change', refreshWeaponChoose);

let removeWeaponMenu = document.getElementById('removeWeaponMenu');
let removeWeaponPrototype = document.getElementById('removeWeaponPrototype');
removeWeaponPrototype.style.display = 'none';
function refreshRemoveWeapon(){
    weaponChooseList.forEach(element=>{
        if(element.Div === null){
            let newChild = removeWeaponPrototype.cloneNode(true);
            newChild.style.display = 'flex';
            newChild.children[0].textContent = element.Item.Name;
            newChild.children[1].src = takeWay(element.Item.ItemId,element.Item.Type,element.Item.SubType);
            newChild.children[2].textContent = 'Заточка: ' + element.Item.Pottential;
            newChild.children[3].textContent = 'Урон: ' + element.Item.Damage;
            removeWeaponPrototype.after(newChild);  
            element.Div = newChild;
            newChild.addEventListener('click',e=>{
                newChild.remove();
                element.Stats.remove();
                weaponChooseList.splice(weaponChooseList.indexOf(element),1);
            });
        }
    })
    
}
let chooseWeaponPrototype = document.getElementById('chooseWeaponPrototype');
weaponPerLevelList[0].forEach(element=>{
    class weapon {
        constructor(div,rank,type){
            this.Div = div;
            this.Rank = rank;
            this.Type = type;
        }
    }
    if(element.Class !== 'Ближний бой'){
        let newChild = chooseWeaponPrototype.cloneNode(true);
        newChild.classList = ['chooseArmorIcon']
        newChild.children[0].textContent = element.Name;
        newChild.children[1].src = takeWay(element.ItemId,element.Type,element.SubType);
        newChild.children[2].textContent = 'Урон: ' + element.Damage;
        chooseWeaponPrototype.after(newChild);
        weaponOnChoose.push(new weapon(newChild,element.Rank,element.SubType));
        newChild.addEventListener('click', e=>{
            let tempItem;
    
            weaponPerLevelList[chooseWeaponLevel.value].forEach(temp =>{
                if(temp.ItemId === element.ItemId){
                    tempItem = temp;
                }
            });
            chooseWeaponMenu.classList.remove('middleChoose');
            weaponChooseList.push(new takenWeapon(null,tempItem));
            refreshRemoveWeapon();
        });
    }
    
});

chooseWeaponListBox.removeChild(chooseWeaponPrototype);

let removeWeapon = document.getElementById('removeWeapon');
removeWeapon.addEventListener('click',e=>{
    removeWeaponMenu.classList.add('middleChoose');
})
let chooseArmorCancel = document.getElementById('chooseArmorCancel');
chooseArmorCancel.addEventListener('click', e=>{
    chooseArmorMenu.classList.remove('middleChoose');
});
let chooseWeaponCancel = document.getElementById('chooseWeaponCancel');
chooseWeaponCancel.addEventListener('click', e=>{
    chooseWeaponMenu.classList.remove('middleChoose');
});
let removeWeaponCancel = document.getElementById('removeWeaponCancel');
removeWeaponCancel.addEventListener('click',e=>{
    removeWeaponMenu.classList.remove('middleChoose');
});





//Конец обработки всего оружия