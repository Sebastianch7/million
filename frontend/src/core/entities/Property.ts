// src/core/entities/Property.ts
export interface PropertyImage {
  idPropertyImage: string;
  idProperty: string;
  file: string;
  enabled: boolean;
}

export interface PropertyTrace {
  idPropertyTrace: string;
  dateSale: string;
  name: string;
  value: number;
  tax: number;
  idProperty: string;
}

export interface Owner {
  idOwner: string;
  name: string;
  address: string;
  photo: string;
  birthday: string;
}

export interface Property {
  idProperty: string;
  name: string;
  address: string;
  price: number;
  codeInternal: string;
  year: number;
  description?: string;
  owner?: Owner;
  images?: PropertyImage[];
  traces?: PropertyTrace[];
}
