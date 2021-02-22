import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'itemFilter'
})
export class ItemFilterPipe implements PipeTransform {

  transform(item: any[],searchQuery: string): any[] {

    if(item!=null && item){
      return item.filter(item=>{
        if(searchQuery && item.itemName.toLowerCase().indexOf(searchQuery.toLowerCase())===-1)  {
        return false;
        }
          return true;
      })
    }else{
      return item;
    }
  }
}
