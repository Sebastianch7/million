"use client";
import { useEffect, useState } from "react";
import { Button, Offcanvas, Form, Row, Col } from "react-bootstrap";

interface Filters {
  name?: string;
  address?: string;
  minPrice?: number;
  maxPrice?: number;
}

interface Props {
  onFilter: (filters: Filters) => void;
  initialFilters?: Filters; // <-- recibe filtros activos desde el padre
}

export default function PropertyFilters({ onFilter, initialFilters }: Props) {
  const [filters, setFilters] = useState<Filters>(initialFilters ?? {});
  const [show, setShow] = useState(false);

  // Sincroniza el estado interno con la prop initialFilters
  useEffect(() => {
    setFilters(initialFilters ?? {});
  }, [initialFilters]);

  // Maneja cambios en inputs (controlados)
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    setFilters((prev) => ({
      ...prev,
      [name]:
        value === ""
          ? undefined
          : name.includes("Price")
            ? Number(value)
            : value,
    }));
  };

  // Aplica filtros: notifica al padre y cierra el offcanvas
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onFilter(filters);
    setShow(false);
  };

  // Limpia localmente y notifica al padre para que limpie también
  const handleClear = () => {
    const empty: Filters = {};
    setFilters(empty);    // limpia inputs del offcanvas
    onFilter(empty);      // notifica al padre para recargar sin filtros
    // No cerramos para que el usuario vea que quedó vacío (opcional)
  };

  return (
    <>
      {/* Botón que abre el offcanvas */}
      <div className="d-flex justify-content-end mb-3">
        <Button variant="dark" onClick={() => setShow(true)}>
          Filters
          {Object.values(filters).filter((v) => v !== undefined && v !== "").length > 0 && (
            <span className="ms-2 badge bg-primary">
              {Object.values(filters).filter((v) => v !== undefined && v !== "").length}
            </span>
          )}
        </Button>
      </div>

      <Offcanvas show={show} onHide={() => setShow(false)} placement="start">
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Filter properties</Offcanvas.Title>
        </Offcanvas.Header>

        <Offcanvas.Body>
          <Form onSubmit={handleSubmit} className="d-grid gap-3">
            <Form.Group controlId="filterName">
              <Form.Label>Name</Form.Label>
              <Form.Control
                name="name"
                type="text"
                value={filters.name ?? ""}
                placeholder="Ej. Apartamento Centro"
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group controlId="filterAddress">
              <Form.Label>Address</Form.Label>
              <Form.Control
                name="address"
                type="text"
                value={filters.address ?? ""}
                placeholder="Ej. Bogotá"
                onChange={handleChange}
              />
            </Form.Group>

            <Row>
              <Col md={6}>
                <Form.Group controlId="filterMinPrice">
                  <Form.Label>Min price</Form.Label>
                  <Form.Control
                    name="minPrice"
                    type="number"
                    value={filters.minPrice ?? ""}
                    placeholder="100000000"
                    onChange={handleChange}
                  />
                </Form.Group>
              </Col>
              <Col md={6}>
                <Form.Group controlId="filterMaxPrice">
                  <Form.Label>Max price</Form.Label>
                  <Form.Control
                    name="maxPrice"
                    type="number"
                    value={filters.maxPrice ?? ""}
                    placeholder="500000000"
                    onChange={handleChange}
                  />
                </Form.Group>
              </Col>
            </Row>

            <div className="d-flex justify-content-between mt-4">
              <Button variant="outline-secondary" onClick={handleClear}>
                Clean
              </Button>
              <div>
                <Button type="submit" variant="dark">
                  Apply filters
                </Button>
              </div>
            </div>
          </Form>
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
}
