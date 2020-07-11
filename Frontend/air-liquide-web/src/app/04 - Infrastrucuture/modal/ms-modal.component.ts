import { Component, OnInit, OnDestroy, Input, ElementRef } from '@angular/core';
import { MsModalService } from './ms-modal.service';


@Component({
  selector: 'app-ms-modal',
  templateUrl: './ms-modal.component.html',
})
export class MsModalComponent implements OnInit, OnDestroy {
  @Input() id: string;
  @Input() title: string;
  private element: any;

  constructor(private modalService: MsModalService, private el: ElementRef) {
    this.element = el.nativeElement;
   }

  ngOnInit() {
    const modal = this;

    // ensure id attribute exists
    if (!this.id) {
        console.error('modal must have an id');
        return;
    }

    // move element to bottom of page (just before </body>) so it can be displayed above everything else
    // dario
    // document.body.appendChild(this.element);

    // close modal on background click
    this.element.addEventListener('click',  (e: any) => {
      if (e.target.className === 'app-ms-modal') {
        modal.close();
      }
    });

    // add self (this modal instance) to the modal service so it's accessible from controllers
    this.modalService.add(this);
  }

  ngOnDestroy() {
    this.modalService.remove(this.id);
    this.element.remove();
  }

  // open modal
  open(): void {
    this.element.style.display = 'block';
    this.element.classList.add('app-ms-modal-open');
  }

  // close modal
  close(): void {
    this.element.style.display = 'none';
    document.body.classList.remove('app-ms-modal-open');
}

}
