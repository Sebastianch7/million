"use client";

import useBootstrap from "@/hooks/useBootstrap";
import { useEffect, useState } from "react";
import { Property } from "@/core/entities/Property";
import { fetchProperties } from "@/core/usecases/fetchProperties";
import PropertyCard from "@/ui/components/PropertyCard";
import PropertyFilters from "@/ui/components/PropertyFilters";
import { Alert, Badge, Button, Spinner } from "react-bootstrap";

export default function HomePage() {
  useBootstrap();
  const [properties, setProperties] = useState<Property[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [activeFilters, setActiveFilters] = useState<any>({});

  const loadProperties = async (filters?: any) => {
    try {
      setLoading(true);
      setError(null);
      const data = await fetchProperties(filters);
      setProperties(data);
      setActiveFilters(filters || {});
    } catch (err) {
      console.error(err);
      setError("Properties could not be loaded");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadProperties();
  }, []);

  return (
    <main>
      <section
        className="position-relative text-white d-flex align-items-center justify-content-center"
        style={{
          backgroundImage:
            "url('https://cdn.millionluxury.com/image-resizing?image=https://maustorageprod.blob.core.windows.net/spinfileuat/Spin/Data/Estate/IMG/5c51c46b24dd4a5895e81a3c6b7eb80f.jpg&width=2000&height=700')",
          backgroundSize: "cover",
          backgroundPosition: "center",
          height: "320px",
        }}
      >
        <div className="bg-black w-100 h-100 position-absolute top-0 start-0"></div>
        <div className="position-relative text-center">
          <h1 className="fw-bold display-5 mb-3">Available Properties</h1>
          <p className="lead">Find your next luxury home</p>
        </div>
      </section>

      <div className="container py-4">
        <PropertyFilters onFilter={loadProperties} />

        {Object.keys(activeFilters).length > 0 && (
          <div className="mb-4">
            <h6 className="fw-bold mb-2">Active filters:</h6>
            <div className="d-flex flex-wrap gap-2">
              {activeFilters.name && (
                <Badge bg="secondary">Name: {activeFilters.name}</Badge>
              )}
              {activeFilters.address && (
                <Badge bg="secondary">Address: {activeFilters.address}</Badge>
              )}
              {activeFilters.minPrice && (
                <Badge bg="secondary">
                  Min: {Number(activeFilters.minPrice).toLocaleString("en-US")}
                </Badge>
              )}
              {activeFilters.maxPrice && (
                <Badge bg="secondary">
                  Max: {Number(activeFilters.maxPrice).toLocaleString("en-US")}
                </Badge>
              )}
            </div>
          </div>
        )}

        {loading && (
          <div className="d-flex justify-content-center py-5">
            <Spinner animation="border" role="status">
              <span className="visually-hidden">Loading...</span>
            </Spinner>
          </div>
        )}

        {error && <div className="alert alert-danger text-center">{error}</div>}

        {!loading && !error && (
          <div className="row g-4">
            {properties.length > 0 ? (
              properties.map((property) => (
                <div className="col-12 col-md-6 col-lg-4" key={property.idProperty}>
                  <PropertyCard property={property} />
                </div>
              ))
            ) : (
              <Alert variant="warning">
                No properties were found matching your filters.
              </Alert>
            )}
          </div>
        )}
      </div>
    </main>
  );
}
