import { ProductImage } from './product-image.model';
import { ProductSize } from './product-size.model';

export class Product {
  constructor(
    public id: string,
    public name: string,
    public image: ProductImage,
    public images: ProductImage[],
    public description: string,
    public quantity: number,
    public price: number,
    public created_on: string,
    public sizes?: ProductSize[]
  ) {}
}
