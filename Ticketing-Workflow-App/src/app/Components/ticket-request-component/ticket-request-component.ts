import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Category, SubCategory, TicketRequest } from '../../Models/Models';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TicketManagmenetService } from '../../Services/ticket-Managment-Service';

@Component({
  selector: 'app-ticket-request-component',
  templateUrl: './ticket-request-component.html',
  styleUrls: ['./ticket-request-component.scss']
})
export class TicketRequestComponent implements OnInit {
  ticketRequestForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    description: new FormControl(''),
    category: new FormControl('', [Validators.required]),
    subcategory: new FormControl('', [Validators.required]),
    uploadFile: new FormControl('', [Validators.required]),
    fileData:new FormControl('')
  });
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  fileSizeError: boolean = false;
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

  uploadFileEvt(upploadedFile: any) {
    this.fileSizeError = false;
    if (upploadedFile.target.files && upploadedFile.target.files[0]) {
      this.fileAttr = '';
      let file: File = upploadedFile.target.files[0];
      //disable uploading more than 2mb file
      if(file.size > 2097152){ 
        this.ticketRequestForm.controls['fileData']?.setErrors({'incorrect': true});
        this.fileSizeError = true;
      }
      this.fileAttr += file.name;
      // HTML5 FileReader API
      let reader = new FileReader();
      reader.readAsDataURL(upploadedFile.target.files[0]);
      // Reset if duplicate uploaded again
      this.fileInput.nativeElement.value = "";
    } else {
      this.fileAttr = 'Choose File';
    }
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
    this.fileInput.nativeElement.value = '';
    this.fileAttr = 'Choose File';
  }
  

}
