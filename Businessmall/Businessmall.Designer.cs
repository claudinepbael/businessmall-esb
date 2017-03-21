﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("ebs.businessmallModel", "FK_OrderProducts_orders", "Order", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Businessmall.Order), "OrderProduct", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Businessmall.OrderProduct), true)]
[assembly: EdmRelationshipAttribute("ebs.businessmallModel", "FK_orders_users", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Businessmall.User), "Order", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Businessmall.Order), true)]
[assembly: EdmRelationshipAttribute("ebs.businessmallModel", "FK_OrderProducts_products", "Product", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Businessmall.Product), "OrderProduct", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Businessmall.OrderProduct), true)]

#endregion

namespace Businessmall
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BusinessmallEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BusinessmallEntities object using the connection string found in the 'BusinessmallEntities' section of the application configuration file.
        /// </summary>
        public BusinessmallEntities() : base("name=BusinessmallEntities", "BusinessmallEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BusinessmallEntities object.
        /// </summary>
        public BusinessmallEntities(string connectionString) : base(connectionString, "BusinessmallEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BusinessmallEntities object.
        /// </summary>
        public BusinessmallEntities(EntityConnection connection) : base(connection, "BusinessmallEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Order> Orders
        {
            get
            {
                if ((_Orders == null))
                {
                    _Orders = base.CreateObjectSet<Order>("Orders");
                }
                return _Orders;
            }
        }
        private ObjectSet<Order> _Orders;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<OrderProduct> OrderProducts
        {
            get
            {
                if ((_OrderProducts == null))
                {
                    _OrderProducts = base.CreateObjectSet<OrderProduct>("OrderProducts");
                }
                return _OrderProducts;
            }
        }
        private ObjectSet<OrderProduct> _OrderProducts;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Product> Products
        {
            get
            {
                if ((_Products == null))
                {
                    _Products = base.CreateObjectSet<Product>("Products");
                }
                return _Products;
            }
        }
        private ObjectSet<Product> _Products;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<User> Users
        {
            get
            {
                if ((_Users == null))
                {
                    _Users = base.CreateObjectSet<User>("Users");
                }
                return _Users;
            }
        }
        private ObjectSet<User> _Users;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Orders EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the OrderProducts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToOrderProducts(OrderProduct orderProduct)
        {
            base.AddObject("OrderProducts", orderProduct);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Products EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProducts(Product product)
        {
            base.AddObject("Products", product);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUsers(User user)
        {
            base.AddObject("Users", user);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ebs.businessmallModel", Name="Order")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Order : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="user_id">Initial value of the user_id property.</param>
        /// <param name="date_ordered">Initial value of the date_ordered property.</param>
        public static Order CreateOrder(global::System.Int32 id, global::System.Int32 user_id, global::System.DateTime date_ordered)
        {
            Order order = new Order();
            order.id = id;
            order.user_id = user_id;
            order.date_ordered = date_ordered;
            return order;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 user_id
        {
            get
            {
                return _user_id;
            }
            set
            {
                Onuser_idChanging(value);
                ReportPropertyChanging("user_id");
                _user_id = StructuralObject.SetValidValue(value, "user_id");
                ReportPropertyChanged("user_id");
                Onuser_idChanged();
            }
        }
        private global::System.Int32 _user_id;
        partial void Onuser_idChanging(global::System.Int32 value);
        partial void Onuser_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime date_ordered
        {
            get
            {
                return _date_ordered;
            }
            set
            {
                Ondate_orderedChanging(value);
                ReportPropertyChanging("date_ordered");
                _date_ordered = StructuralObject.SetValidValue(value, "date_ordered");
                ReportPropertyChanged("date_ordered");
                Ondate_orderedChanged();
            }
        }
        private global::System.DateTime _date_ordered;
        partial void Ondate_orderedChanging(global::System.DateTime value);
        partial void Ondate_orderedChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_OrderProducts_orders", "OrderProduct")]
        public EntityCollection<OrderProduct> OrderProducts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<OrderProduct>("ebs.businessmallModel.FK_OrderProducts_orders", "OrderProduct");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<OrderProduct>("ebs.businessmallModel.FK_OrderProducts_orders", "OrderProduct", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_orders_users", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ebs.businessmallModel.FK_orders_users", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ebs.businessmallModel.FK_orders_users", "User").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ebs.businessmallModel.FK_orders_users", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("ebs.businessmallModel.FK_orders_users", "User", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ebs.businessmallModel", Name="OrderProduct")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class OrderProduct : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new OrderProduct object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="order_id">Initial value of the order_id property.</param>
        /// <param name="product_id">Initial value of the product_id property.</param>
        /// <param name="qty">Initial value of the qty property.</param>
        public static OrderProduct CreateOrderProduct(global::System.Int32 id, global::System.Int32 order_id, global::System.Int32 product_id, global::System.Int32 qty)
        {
            OrderProduct orderProduct = new OrderProduct();
            orderProduct.id = id;
            orderProduct.order_id = order_id;
            orderProduct.product_id = product_id;
            orderProduct.qty = qty;
            return orderProduct;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 order_id
        {
            get
            {
                return _order_id;
            }
            set
            {
                Onorder_idChanging(value);
                ReportPropertyChanging("order_id");
                _order_id = StructuralObject.SetValidValue(value, "order_id");
                ReportPropertyChanged("order_id");
                Onorder_idChanged();
            }
        }
        private global::System.Int32 _order_id;
        partial void Onorder_idChanging(global::System.Int32 value);
        partial void Onorder_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 product_id
        {
            get
            {
                return _product_id;
            }
            set
            {
                Onproduct_idChanging(value);
                ReportPropertyChanging("product_id");
                _product_id = StructuralObject.SetValidValue(value, "product_id");
                ReportPropertyChanged("product_id");
                Onproduct_idChanged();
            }
        }
        private global::System.Int32 _product_id;
        partial void Onproduct_idChanging(global::System.Int32 value);
        partial void Onproduct_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 qty
        {
            get
            {
                return _qty;
            }
            set
            {
                OnqtyChanging(value);
                ReportPropertyChanging("qty");
                _qty = StructuralObject.SetValidValue(value, "qty");
                ReportPropertyChanged("qty");
                OnqtyChanged();
            }
        }
        private global::System.Int32 _qty;
        partial void OnqtyChanging(global::System.Int32 value);
        partial void OnqtyChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_OrderProducts_orders", "Order")]
        public Order Order
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("ebs.businessmallModel.FK_OrderProducts_orders", "Order").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("ebs.businessmallModel.FK_OrderProducts_orders", "Order").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Order> OrderReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Order>("ebs.businessmallModel.FK_OrderProducts_orders", "Order");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Order>("ebs.businessmallModel.FK_OrderProducts_orders", "Order", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_OrderProducts_products", "Product")]
        public Product Product
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("ebs.businessmallModel.FK_OrderProducts_products", "Product").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("ebs.businessmallModel.FK_OrderProducts_products", "Product").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Product> ProductReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Product>("ebs.businessmallModel.FK_OrderProducts_products", "Product");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Product>("ebs.businessmallModel.FK_OrderProducts_products", "Product", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ebs.businessmallModel", Name="Product")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Product : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Product object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="price">Initial value of the price property.</param>
        /// <param name="qty_at_hand">Initial value of the qty_at_hand property.</param>
        public static Product CreateProduct(global::System.Int32 id, global::System.String name, global::System.Decimal price, global::System.Int32 qty_at_hand)
        {
            Product product = new Product();
            product.id = id;
            product.name = name;
            product.price = price;
            product.qty_at_hand = qty_at_hand;
            return product;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false, "name");
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal price
        {
            get
            {
                return _price;
            }
            set
            {
                OnpriceChanging(value);
                ReportPropertyChanging("price");
                _price = StructuralObject.SetValidValue(value, "price");
                ReportPropertyChanged("price");
                OnpriceChanged();
            }
        }
        private global::System.Decimal _price;
        partial void OnpriceChanging(global::System.Decimal value);
        partial void OnpriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 qty_at_hand
        {
            get
            {
                return _qty_at_hand;
            }
            set
            {
                Onqty_at_handChanging(value);
                ReportPropertyChanging("qty_at_hand");
                _qty_at_hand = StructuralObject.SetValidValue(value, "qty_at_hand");
                ReportPropertyChanged("qty_at_hand");
                Onqty_at_handChanged();
            }
        }
        private global::System.Int32 _qty_at_hand;
        partial void Onqty_at_handChanging(global::System.Int32 value);
        partial void Onqty_at_handChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_OrderProducts_products", "OrderProduct")]
        public EntityCollection<OrderProduct> OrderProducts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<OrderProduct>("ebs.businessmallModel.FK_OrderProducts_products", "OrderProduct");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<OrderProduct>("ebs.businessmallModel.FK_OrderProducts_products", "OrderProduct", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ebs.businessmallModel", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new User object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="username">Initial value of the username property.</param>
        /// <param name="password">Initial value of the password property.</param>
        /// <param name="is_admin">Initial value of the is_admin property.</param>
        public static User CreateUser(global::System.Int32 id, global::System.String username, global::System.String password, global::System.Boolean is_admin)
        {
            User user = new User();
            user.id = id;
            user.username = username;
            user.password = password;
            user.is_admin = is_admin;
            return user;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value, "id");
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String username
        {
            get
            {
                return _username;
            }
            set
            {
                OnusernameChanging(value);
                ReportPropertyChanging("username");
                _username = StructuralObject.SetValidValue(value, false, "username");
                ReportPropertyChanged("username");
                OnusernameChanged();
            }
        }
        private global::System.String _username;
        partial void OnusernameChanging(global::System.String value);
        partial void OnusernameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                OnpasswordChanging(value);
                ReportPropertyChanging("password");
                _password = StructuralObject.SetValidValue(value, false, "password");
                ReportPropertyChanged("password");
                OnpasswordChanged();
            }
        }
        private global::System.String _password;
        partial void OnpasswordChanging(global::System.String value);
        partial void OnpasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String first_name
        {
            get
            {
                return _first_name;
            }
            set
            {
                Onfirst_nameChanging(value);
                ReportPropertyChanging("first_name");
                _first_name = StructuralObject.SetValidValue(value, true, "first_name");
                ReportPropertyChanged("first_name");
                Onfirst_nameChanged();
            }
        }
        private global::System.String _first_name;
        partial void Onfirst_nameChanging(global::System.String value);
        partial void Onfirst_nameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String last_name
        {
            get
            {
                return _last_name;
            }
            set
            {
                Onlast_nameChanging(value);
                ReportPropertyChanging("last_name");
                _last_name = StructuralObject.SetValidValue(value, true, "last_name");
                ReportPropertyChanged("last_name");
                Onlast_nameChanged();
            }
        }
        private global::System.String _last_name;
        partial void Onlast_nameChanging(global::System.String value);
        partial void Onlast_nameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean is_admin
        {
            get
            {
                return _is_admin;
            }
            set
            {
                Onis_adminChanging(value);
                ReportPropertyChanging("is_admin");
                _is_admin = StructuralObject.SetValidValue(value, "is_admin");
                ReportPropertyChanged("is_admin");
                Onis_adminChanged();
            }
        }
        private global::System.Boolean _is_admin;
        partial void Onis_adminChanging(global::System.Boolean value);
        partial void Onis_adminChanged();

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ebs.businessmallModel", "FK_orders_users", "Order")]
        public EntityCollection<Order> Orders
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Order>("ebs.businessmallModel.FK_orders_users", "Order");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Order>("ebs.businessmallModel.FK_orders_users", "Order", value);
                }
            }
        }

        #endregion

    }

    #endregion

}