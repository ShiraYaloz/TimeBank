import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/classes/category';
import { CategoryMember } from 'src/app/classes/category-member';
import { MemPlusCat } from 'src/app/classes/mem-plus-cat';
import { AllCategoriesService } from 'src/app/services/all-categories.service';

@Component({
  selector: 'app-set-action',
  templateUrl: './set-action.component.html',
  styleUrls: ['./set-action.component.css']
})
export class SetActionComponent implements OnInit {


  isChack:boolean=false;
  categories:Array<MemPlusCat> = new Array<MemPlusCat>();

   selectedCat:MemPlusCat  = new MemPlusCat("","","","",new Category("",0,false,0),"",false,"","",false,0,0);
  constructor(private CategoriesCon:AllCategoriesService,private router:Router) { 
  }
  ngOnInit(): void {
    this.loadData();
  }
  loadData()
  {
 /* let b:Boolean = this.CategoriesCon.loadData()
  if(b){
    this.categories = this.CategoriesCon.categories
    console.log("פעולת השמה")
    console.log(this.categories)
   
  }
  else
  console.log("error") */   
  this.CategoriesCon.getAllMemberCategory().subscribe(
   (myData)=>
   { 
   this.categories = myData;
   console.log("in set action ts");

   console.log(this.categories);
     
     },
     (myErr)=>
     {  alert(myErr.message);}
    );
   
  }
  detiels(cat:MemPlusCat){
    this.isChack=!this.isChack;
    this.selectedCat = cat;
  }
}

