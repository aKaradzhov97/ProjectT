// Decorators and Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  ElementRef,
  Input,
  OnDestroy,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';

// Services
import { ModalService } from '../../../core/services/modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: 'modal.component.html',
  styleUrls: ['modal.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class ModalComponent implements OnInit, OnDestroy {
  @Input() id: string;

  private element: any;

  constructor(private modalService: ModalService, private el: ElementRef) {
    this.element = el.nativeElement;
  }

  ngOnInit(): void {
    // Add self (this modal instance) to the modal service so it's accessible from controllers
    this.modalService.add(this);
  }

  // Remove self from modal service when component is destroyed
  ngOnDestroy(): void {
    this.modalService.remove(this.id);
    this.element.remove();
    document.body.classList.remove('app-modal-open');
  }

  // Open modal
  open(): void {
    // Ensure id attribute exists
    if (!this.id) {
      console.error('Modal must have an id!');
      return;
    }

    // Move element to bottom of page (just before </body>) so it can be displayed above everything else
    document.body.appendChild(this.element);

    // Attach the event listeners, so when user clicks outside of the modal, a remove is triggered.
    this.attachListeners();

    // Display the modal and add a class to the body to disable scrolling
    // and add a dark transparent background around the modal.
    this.element.style.display = 'block';
    document.body.classList.add('app-modal-open');
  }

  // Close modal
  close(): void {
    // Here, we want to remove the element from the DOM when the modal is closed, to avoid
    // "FLOODING" the dom with unnecessary hidden modals.
    this.element.remove();

    // And of course, we enable scrolling once again and remove the dark transparent background.
    document.body.classList.remove('app-modal-open');
  }

  private attachListeners(): void {
    // Close modal on background click
    this.element.addEventListener('click', (el) => {
      if (el.target.className === 'app-modal-background') {
        this.close();
      }
    });

    this.element.addEventListener('click', (el) => {
      if (el.target.className === 'app-modal') {
        this.close();
      }
    });

    this.element.addEventListener('touchend', (el) => {
      if (el.target.className === 'app-modal-background') {
        this.close();
      }
    });

    this.element.addEventListener('touchend', (el) => {
      if (el.target.className === 'app-modal') {
        this.close();
      }
    });
  }
}
