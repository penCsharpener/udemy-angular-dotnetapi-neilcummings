import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss'],
})
export class PagingHeaderComponent implements OnInit {
  @Input() pageNumber: number;
  @Input() pageSize: number;
  @Input() totalCount: number;
  paginationRange: string;

  constructor() {}

  ngOnInit(): void {}

  ngOnChanges() {
    this.calculatePaginationRange();
  }

  private calculatePaginationRange() {
    const startPage = (this.pageNumber - 1) * this.pageSize + 1;
    let endPage = this.totalCount;

    if (this.pageNumber * this.pageSize > this.totalCount) {
      endPage = this.pageNumber * this.pageSize;
    }

    this.paginationRange = `${startPage} - ${endPage}`;
  }
}
