import { Property } from "../entities/Property";
import { getProperties, PropertyFilters } from "@/infrastructure/api/propertyService";

/**
 * Caso de uso: obtener propiedades desde el backend con filtros opcionales (name, address, price).
 *
 * Esta capa define la intención de obtener propiedades,
 * y delega la implementación técnica (fetch) a la infraestructura.
 */
export async function fetchProperties(filters?: PropertyFilters): Promise<Property[]> {
  try {
    const properties = await getProperties(filters);
    //properties.sort((a, b) => a.price - b.price);
    return properties;
  } catch (error) {
    console.error("Error getting fetchProperties usecase:", error);
    throw error;
  }
}
