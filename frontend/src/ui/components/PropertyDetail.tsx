"use client";
import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { getPropertyById } from "@/infrastructure/api/propertyService";
import { Property } from "@/core/entities/Property";
import { Carousel, Spinner } from "react-bootstrap";
import Link from "next/link";

export default function PropertyDetail() {
    const { id } = useParams();
    const [property, setProperty] = useState<Property | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const load = async () => {
            try {
                if (!id) return;
                const p = await getPropertyById(id);
                setProperty(p);
            } catch (err) {
                console.error(err);
                setError("The property could not be loaded");
            } finally {
                setLoading(false);
            }
        };
        load();
    }, [id]);

    if (loading)
        return (
            <div className="container py-5 text-center">
                <Spinner animation="border" />
            </div>
        );

    if (error)
        return (
            <div className="container py-5 alert alert-danger">{error}</div>
        );

    if (!property)
        return (
            <div className="container py-5">Property not found.</div>
        );

    const images = property.images?.filter((img) => img.enabled) ?? [];

    return (
        <main className="bg-light pb-5">
            <div className="container">
                <div className="row">
                    <div className="col-12">
                        <section className="position-relative">
                            <Carousel fade controls={images.length > 1} indicators={images.length > 1}>
                                {images.length > 0 ? (
                                    images.map((img, idx) => (
                                        <Carousel.Item key={idx}>
                                            <img
                                                src={img.file}
                                                className="d-block w-100"
                                                style={{ height: "550px", objectFit: "cover" }}
                                                alt={`Imagen ${idx + 1}`}
                                            />
                                        </Carousel.Item>
                                    ))
                                ) : (
                                    <Carousel.Item>
                                        <img
                                            src="https://cdn.millionluxury.com/image-resizing?image=https://maustorageprod.blob.core.windows.net/spinfileuat/Spin/Data/Estate/IMG/ceb693ad6b7643fc8c1be271d6a9c068.svg?v=740"
                                            className="d-block w-100"
                                            style={{
                                                height: "500px",
                                                objectFit: "contain",
                                                objectPosition: "center",
                                                backgroundColor: "#000000ff",
                                            }}
                                            alt="Sin imagen"
                                        />
                                    </Carousel.Item>
                                )}
                            </Carousel>
                        </section>
                    </div>

                </div>
            </div>
            <div className="container mt-5">
                <div className="mb-4">
                    <Link href="/" className="btn btn-dark btn-sm">
                        Back to list
                    </Link>
                </div>
                <div className="row">
                    <div className="col-lg-8">
                        <span className="badge bg-light text-secondary border mb-2">
                            {property.year}
                        </span>
                        <h2 className="fw-bold">{property.name}</h2>
                        <p className="text-muted">{property.address}</p>

                        <h2 className="text-dark fw-bold mb-3">
                            ${property.price.toLocaleString("es-CO")}
                        </h2>

                        <p className="text-muted small">
                            Internal code: <strong>{property.codeInternal}</strong>
                        </p>

                        <hr />

                        {property.owner && (
                            <div className="d-flex align-items-center gap-3 my-4">
                                <img
                                    src={property.owner.photo}
                                    alt={property.owner.name}
                                    className="rounded-circle border"
                                    style={{ width: "70px", height: "70px", objectFit: "cover" }}
                                />
                                <div>
                                    <h6 className="mb-1">{property.owner.name}</h6>
                                    <p className="text-muted small mb-0">
                                        {property.owner.address}
                                    </p>
                                </div>
                            </div>
                        )}
                    </div>

                    <div className="col-lg-4">
                        <div className="card shadow-sm border-0">
                            <div className="card-body">
                                <h5 className="card-title">Sales History</h5>
                                {property.traces && property.traces.length > 0 ? (
                                    <ul className="list-group list-group-flush mt-3">
                                        {property.traces.map((trace) => (
                                            <li key={trace.idPropertyTrace} className="list-group-item">
                                                <strong>{trace.name}</strong>
                                                <p className="mb-1 text-muted small">
                                                    Date:{" "}
                                                    {new Date(trace.dateSale).toLocaleDateString("es-CO")}
                                                </p>
                                                <p className="mb-1">
                                                    Price:{" "}
                                                    <span className="text-success fw-bold">
                                                        ${trace.value.toLocaleString("es-CO")}
                                                    </span>
                                                </p>
                                                <p className="text-muted small mb-0">
                                                    Tax: {(trace.tax * 100).toFixed(1)}%
                                                </p>
                                            </li>
                                        ))}
                                    </ul>
                                ) : (
                                    <p className="text-muted small mt-2">
                                        No transaction records
                                    </p>
                                )}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    );
}
