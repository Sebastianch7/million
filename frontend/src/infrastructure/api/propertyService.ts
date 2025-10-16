import { Property } from "@/core/entities/Property";

const API_URL =
  process.env.NEXT_PUBLIC_API_URL || "http://localhost:5076/api/Property";

export interface PropertyFilters {
  name?: string;
  address?: string;
  minPrice?: number;
  maxPrice?: number;
}

/**
 * Obtiene propiedades desde la API .NET
 * Si hay filtros, usa el endpoint /filter
 */
export async function getProperties(filters?: PropertyFilters): Promise<Property[]> {
  try {
    let url = API_URL;

    // Si hay filtros, construimos la query
    if (filters && Object.keys(filters).length > 0) {
      const params = new URLSearchParams();

      if (filters.name) params.append("name", filters.name);
      if (filters.address) params.append("address", filters.address);
      if (filters.minPrice) params.append("minPrice", filters.minPrice.toString());
      if (filters.maxPrice) params.append("maxPrice", filters.maxPrice.toString());

      url = `${API_URL}/filter?${params}`;
    }

    const res = await fetch(url, { method: "GET" });
    if (!res.ok) throw new Error(`Error getting properties (${res.status})`);

    return res.json();
  } catch (error) {
    console.error("Error in getProperties:", error);
    throw error;
  }
}

/**
 * Obtiene una propiedad individual por ID
 */
export async function getPropertyById(id: string): Promise<Property> {
  try {
    const res = await fetch(`${API_URL}/${id}`);
    if (!res.ok) throw new Error("Property not found");
    return res.json();
  } catch (error) {
    console.error("Error in getPropertyById:", error);
    throw error;
  }
}
