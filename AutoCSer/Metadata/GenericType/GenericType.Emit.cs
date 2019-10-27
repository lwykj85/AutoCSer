﻿using System;
using System.Collections.Generic;
using AutoCSer.Threading;
using System.Reflection;

namespace AutoCSer.Metadata
{
    /// <summary>
    /// 泛型类型元数据
    /// </summary>
    internal abstract partial class GenericType
    {
        /// <summary>
        /// 客户端回调转换
        /// </summary>
        /// <returns></returns>
        internal abstract MethodInfo TcpClientCallbackGetMethod { get; }
        /// <summary>
        /// 同步等待调用类型
        /// </summary>
        /// <returns></returns>
        internal abstract System.Type TcpAutoWaitReturnValueType { get; }
        /// <summary>
        /// 弹出同步等待调用节点
        /// </summary>
        /// <returns></returns>
        internal abstract MethodInfo TcpAutoWaitReturnValuePopMethod { get; }
        ///// <summary>
        ///// 获取服务端回调转换
        ///// </summary>
        ///// <returns></returns>
        //internal abstract MethodInfo TcpServerCallbackGetMethod { get; }
        /// <summary>
        /// 服务端回调委托返类型
        /// </summary>
        internal abstract System.Type TcpServerCallbackType { get; }
        /// <summary>
        /// 服务端回调委托返类型
        /// </summary>
        internal abstract System.Type TcpServerCallbackEmitType { get; }
    }
    /// <summary>
    /// 泛型类型元数据
    /// </summary>
    internal sealed partial class GenericType<Type> : GenericType
    {
        /// <summary>
        /// 客户端回调转换
        /// </summary>
        /// <returns></returns>
        internal override MethodInfo TcpClientCallbackGetMethod
        {
            get { return ((Func<Func<AutoCSer.Net.TcpServer.ReturnValue<Type>, bool>, Action<AutoCSer.Net.TcpServer.ReturnValue<Type>>>)AutoCSer.Net.TcpServer.Emit.ClientCallback<Type>.Get).Method; }
        }
        /// <summary>
        /// 同步等待调用类型
        /// </summary>
        /// <returns></returns>
        internal override System.Type TcpAutoWaitReturnValueType
        {
            get { return typeof(AutoCSer.Net.TcpServer.AutoWaitReturnValue<Type>); }
        }
        /// <summary>
        /// 弹出同步等待调用节点
        /// </summary>
        /// <returns></returns>
        internal override MethodInfo TcpAutoWaitReturnValuePopMethod
        {
            get { return ((Func<AutoCSer.Net.TcpServer.AutoWaitReturnValue<Type>>)AutoCSer.Net.TcpServer.AutoWaitReturnValue<Type>.Pop).Method; }
        }
        ///// <summary>
        ///// 获取服务端回调转换
        ///// </summary>
        ///// <returns></returns>
        //internal override MethodInfo TcpServerCallbackGetMethod
        //{
        //    get { return ((Func<Func<AutoCSer.Net.TcpServer.ReturnValue<Type>, bool>, Func<Type, bool>>)AutoCSer.Net.TcpServer.Emit.ServerCallback<Type>.Get).Method; }
        //}
        /// <summary>
        /// 服务端回调委托返类型
        /// </summary>
        internal override System.Type TcpServerCallbackType
        {
            get { return typeof(AutoCSer.Net.TcpServer.ServerCallback<Type>); }
        }
        /// <summary>
        /// 服务端回调委托返类型
        /// </summary>
        internal override System.Type TcpServerCallbackEmitType
        {
            get { return typeof(Func<AutoCSer.Net.TcpServer.ReturnValue<Type>, bool>); }
        }
    }
}
