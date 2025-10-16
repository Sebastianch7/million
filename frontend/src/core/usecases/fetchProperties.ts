import { Property } from "../entities/Property";
import { getProperties, PropertyFilters } from "@/infrastructure/api/propertyService";


export async function fetchProperties(filters?: PropertyFilters): Promise<Property[]> {
  try {
    const properties = await getProperties(filters);
    properties.sort((a, b) => a.price - b.price);
    return properties;
  } catch (error) {
    console.error("Error getting fetchProperties usecase:", error);
    throw error;
  }
}
