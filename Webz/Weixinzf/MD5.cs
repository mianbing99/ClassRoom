using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;

//namespace Webz.Weixinzf {
//    // 摘要: 
//    //     表示 System.Security.Cryptography.MD5 哈希算法的所有实现均从中继承的抽象类。
//    [ComVisible(true)]
//    public abstract class MD5 : HashAlgorithm {
//        // 摘要: 
//        //     初始化 System.Security.Cryptography.MD5 的新实例。
//        protected  MD5();

//        // 摘要: 
//        //     创建 System.Security.Cryptography.MD5 哈希算法的默认实现的实例。
//        //
//        // 返回结果: 
//        //     System.Security.Cryptography.MD5 哈希算法的新实例。
//        //
//        // 异常: 
//        //   System.Reflection.TargetInvocationException:
//        //     该算法在使用中启用了联邦信息处理标准 (FIPS) 模式，但与 FIPS 不兼容。
//        public static MD5 Create();
//        //
//        // 摘要: 
//        //     创建 System.Security.Cryptography.MD5 哈希算法的指定实现的实例。
//        //
//        // 参数: 
//        //   algName:
//        //     要使用的 System.Security.Cryptography.MD5 的特定实现的名称。
//        //
//        // 返回结果: 
//        //     System.Security.Cryptography.MD5 的指定实现的新实例。
//        //
//        // 异常: 
//        //   System.Reflection.TargetInvocationException:
//        //     由 algName 参数描述的算法在使用中已启用联邦信息处理标准 (FIPS) 模式，但与 FIPS 不兼容。
//        public static MD5 Create(string algName);
//    }
//}