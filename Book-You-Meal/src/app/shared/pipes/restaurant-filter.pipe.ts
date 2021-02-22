import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'restaurantFilter'
})
export class RestaurantFilterPipe implements PipeTransform {

  transform(item: any[],searchQuery: string): any[] {

    if(item){
      return item.filter(item=>{
        if(searchQuery && item.restaurantName.toLowerCase().indexOf(searchQuery.toLowerCase())===-1)  {
        return false;
        }
          return true;
      })
    }else{
      return item;
    }
  }

}
