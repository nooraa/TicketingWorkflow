import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Category, SubCategory, TicketRequest } from '../../Models/Models';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { TicketManagmenetService } from '../../Services/ticket-Managment-Service';


@Component({
  selector: 'app-ticket-request-component',
  templateUrl: './ticket-request-component.html',
  styleUrls: ['./ticket-request-component.scss']
})
export class TicketRequestComponent implements OnInit {
  ticketRequestForm = new FormGroup({
    title: new FormControl(''),
    email: new FormControl(''),
    description: new FormControl(''),
    category: new FormControl(''),
    subcategory: new FormControl('')
  });

  myControl = new FormControl();
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  filtredSubcategories: SubCategory[] = [];
  @ViewChild('fileInput') fileInput: ElementRef = new ElementRef(null);
  fileAttr = 'Choose File';

  constructor(private ticketService: TicketManagmenetService) {
  }

  ngOnInit(): void {
    this.getCategories();
    this.getSubcategories();
  }

  getCategories(): void {
    this.ticketService.getCategories()
      .subscribe(categories => this.categories = categories);
  }

  getSubcategories(): void {
    this.ticketService.getSubCategories()
      .subscribe(subcategories => this.subcategories = subcategories);
  }

  toggleSubcategories(categoryId: number): boolean {
    this.filtredSubcategories = this.subcategories.filter(sc => sc.categoryId === categoryId);
    return this.filtredSubcategories.length !== 0;
  }

  getOptionText(option: any) {
    if (option) return option.name;
  }

  onSubmit() {
    let submittedTicket: TicketRequest = {
      title: this.ticketRequestForm.controls['title'].value,
      email: this.ticketRequestForm.controls['email'].value,
      description: this.ticketRequestForm.controls['description'].value,
      categoryId: this.ticketRequestForm.controls['category'].value?.id,
      subcategoryId: this.ticketRequestForm.controls['subcategory'].value?.id,
    };
    let res: boolean = false;
    this.ticketService.saveTicketMetaData(submittedTicket).subscribe(res => {
      console.log(res);
    });
    this.ticketRequestForm.reset();
  }

}
